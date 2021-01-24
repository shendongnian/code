    class CharacterConvertBehavior : DependencyObject
    {
        public static bool GetConvertEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(ConvertEnableProperty);
        }
        public static void SetConvertEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(ConvertEnableProperty, value);
        }
        // Using a DependencyProperty as the backing store for ConvertEnable.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConvertEnableProperty =
            DependencyProperty.RegisterAttached("ConvertEnable", typeof(bool), typeof(CharacterConvertBehavior), new PropertyMetadata(ConvertEnableChanged));
        private static void ConvertEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if ((bool)e.NewValue == true)
                textBox.PreviewKeyDown += TextBox_ConvertHandler;
            else
                textBox.PreviewKeyDown -= TextBox_ConvertHandler;
        }
        #region Convert Handler
        private static void TextBox_ConvertHandler(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (e.Key == Key.Oem4)  // "["
            {
                string convertString = "\\u0001";
                TextCompositionManager.StartComposition(new TextComposition(InputManager.Current, textBox, convertString));
                e.Handled = true;
            }
        }
        #endregion
    }
