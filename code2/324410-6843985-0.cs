       class MyStackPanel : StackPanel
        {
             #region Image dependency property
    
             public  MyStackPanel()
             {
    
             }
    
            
            public static readonly DependencyProperty ColorProperty;
    
            
            public static Brush GetColor(DependencyObject obj)
            {
                return (Brush)obj.GetValue(ColorProperty);
            }
    
            
            public static void SetColor(DependencyObject obj, Brush value)
            {
                obj.SetValue(ColorProperty, value);
            }
    
            #endregion
    
            static MyStackPanel()
            {
                //register attached dependency property
                var metadata = new FrameworkPropertyMetadata((Brush) null);
                ColorProperty = DependencyProperty.RegisterAttached("Brush",
                                                                    typeof (Brush),
                                                                    typeof(MyStackPanel), metadata);
            }
    
            //whenever stackpanel is initialized, it will look for it's children. It will //then pick the value of property set by it's children and apply it to itself
            protected override void OnInitialized(EventArgs e)
            {
                base.OnInitialized(e);
    
                foreach (UIElement element in this.Children)
                {
                    this.Background = MyStackPanel.GetColor(element);
                }
            }
        }
