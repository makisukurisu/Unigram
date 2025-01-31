﻿using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;

namespace Telegram.Controls
{
    public class SettingsFooter : Control
    {
        public SettingsFooter()
        {
            DefaultStyleKey = typeof(SettingsFooter);
        }

        #region Text

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(SettingsFooter), new PropertyMetadata(string.Empty));

        #endregion

        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new SettingsFooterAutomationPeer(this);
        }
    }

    public class SettingsFooterAutomationPeer : FrameworkElementAutomationPeer
    {
        private readonly SettingsFooter _owner;

        public SettingsFooterAutomationPeer(SettingsFooter owner)
            : base(owner)
        {
            _owner = owner;
        }

        protected override string GetClassNameCore()
        {
            return "TextBlock";
        }

        protected override string GetNameCore()
        {
            return _owner.Text;
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return AutomationControlType.Text;
        }
    }
}
