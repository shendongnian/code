     public static class ComboBoxBehaviour
        {
            //holding reference of MainWindow class to update the textBlock
            public static MainWindow windoewRef ;
    
            public static bool GetTest(ComboBoxItem target)
            {
                return (bool)target.GetValue(TestAttachedProperty);
            }
    
            public static void SetTest(ComboBoxItem target, bool value)
            {
                target.SetValue(TestAttachedProperty, value);
            }
    
            public static readonly DependencyProperty TestAttachedProperty = DependencyProperty.RegisterAttached("Test", typeof(bool), typeof(ComboBoxBehaviour), new UIPropertyMetadata(false, OnMouseOverChanged));
    
            static void OnMouseOverChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
            {
                ComboBoxItem item = o as ComboBoxItem;
                if ((bool)e.NewValue)
                {
                    // I am setting text of a textblock for testing once mouse is over an item
                    windoewRef.textBlock.Text = item.Content.ToString();
                }
                else
                {
                    //setting text to "" once mouse has been moved  
                    windoewRef.textBlock.Text = "";
                }
            }
        }
