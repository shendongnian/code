    public class MyButtonedCtrl : ContentControl
        {
            static MyButtonedCtrl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(MyButtonedCtrl), new FrameworkPropertyMetadata(typeof(MyButtonedCtrl)));      
            }
    
            #region CommandForFirstButton
            public ICommand CommandForFirstButton
            {
                get { return (ICommand)GetValue(CommandForFirstButtonProperty); }
                set { SetValue(CommandForFirstButtonProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for CommandForFirstButton.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CommandForFirstButtonProperty =
                DependencyProperty.Register("CommandForFirstButton", typeof(ICommand), typeof(MyButtonedCtrl), new UIPropertyMetadata(null));
            #endregion
    
            #region CommandForSecondButton
            public ICommand CommandForSecondButton
            {
                get { return (ICommand)GetValue(CommandForSecondButtonProperty); }
                set { SetValue(CommandForSecondButtonProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for CommandForSecondButton.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CommandForSecondButtonProperty =
                DependencyProperty.Register("CommandForSecondButton", typeof(ICommand), typeof(MyButtonedCtrl), new UIPropertyMetadata(null));
            #endregion
        }
