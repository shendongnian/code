    public class MyCustomButton : System.Windows.Controls.Button
    {
        static MyCustomButton()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(
                typeof(MyCustomButton),
                new FrameworkPropertyMetadata(typeof(MyCustomButton)));
        }
        public MyCustomButton()
            : base()
        {
        }
        #region CurrentCommonVisualState Property
        private static readonly DependencyPropertyKey CurrentCommonVisualStatePropertyKey =
            DependencyProperty.RegisterReadOnly(
                "CurrentCommonVisualState",
                typeof(string),
                typeof(MyCustomButton));
        public static readonly DependencyProperty CurrentCommonVisualStateProperty =
            MyCustomButton.CurrentCommonVisualStatePropertyKey.DependencyProperty;
        [Category("Miscellaneous")]
        [Bindable(true)]
        [ReadOnly(true)]
        public string CurrentcommonVisualState
        {
            get { return (string)base.GetValue(CurrentCommonVisualStateProperty); }
            protected set { base.SetValue(CurrentCommonVisualStatePropertyKey, value); }
        }
        #endregion CurrentCommonVisualState Property
        #region VisualStateManager Methods
        protected T GetTemplateChild<T>(string name) where T : DependencyObject
        {
            return GetTemplateChild(name) as T;
        }
        // In WPF, in order to use the VSM, the VSM must be the first child of
        // your root control template element and that element must be derived
        // from System.Windows.Controls.Panel (e.g., like a Grid control).
        // 
        // This restriction no longer exists with Windows Store apps.
        //
        // But this is why the first parameter to this method is of type
        // Panel.
        protected VisualStateGroup GetVisualStateGroup(Panel visualStateManagerElement,
            string visualStateGroupName)
        {
            if (visualStateManagerElement == null)
            {
                return null;
            }
            VisualStateGroup result = null;
            var visualStateGroups = 
                VisualStateManager.GetVisualStateGroups(visualStateManagerElement);
            foreach (VisualStateGroup vsg in visualStateGroups)
            {
                if (vsg.Name == visualStateGroupName)
                {
                    result = vsg;
                    break;
                }
            }
            return result;
        }
        // When the control changes visual state, get the name of the
        // current visual state from the CommonStates visual state group
        // and set the CurrentCommonVisualState property.
        //
        // Then, you could potentially bind to that property.
        internal override void ChangeVisualState(bool useTransitions)
        {
            // Using IL Spy, look at PresentationFramework.dll and see how
            // MS implements this method. We're going to add some
            // functionality here to get the current visual state.
            base.ChangeVisualStat(useTransitions);
            Panel templateRoot = this.GetTemplateChild<Panel>("TemplateRoot");
            VisualStateGroup vsg = this.GetVisualStateGroup(templateRoot, "CommonStates");
            if (vsg != null && vsg.CurrentState != null)
            {
                this.CurrentCommonVisualState = vsg.CurrentState.Name;
            }
        }
    }
