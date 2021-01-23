    namespace System.Windows.Controls
    {
        public class ChildWindowExt : ChildWindow
        {
            public static readonly DependencyProperty IsOpenedProperty =
              DependencyProperty.Register(
              "IsOpened",
              typeof(bool),
              typeof(ChildWindowExt),
              new PropertyMetadata(false, IsOpenedChanged));
    
            private static void IsOpenedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if ((bool)e.NewValue == false)
                {
                    ChildWindowExt window = d as ChildWindowExt;
                    window.Close();
                }
                else if ((bool)e.NewValue == true)
                {
                    ChildWindowExt window = d as ChildWindowExt;
                    window.Show();
                }
            }
    
            public bool IsOpened
            {
                get { return (bool)GetValue(IsOpenedProperty); }
                set { SetValue(IsOpenedProperty, value); }
            }
    
            protected override void OnClosing(ComponentModel.CancelEventArgs e)
            {
                this.IsOpened = false;
                base.OnClosing(e);
            }
    
            protected override void OnOpened()
            {
                this.IsOpened = true;
                base.OnOpened();
            }
        }
    }
