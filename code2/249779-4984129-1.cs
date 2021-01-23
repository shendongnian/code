    public class b:Behaviors
    {
        #region Attached DP registration
        public static int GetScrolledLine(TextBox obj)
        {
            return (int)obj.GetValue(ScrolledLineProperty);
        }
        public static void SetScrolledLine(TextBox obj, int value)
        {
            obj.SetValue(ScrolledLineProperty, value);
        }
 
        #endregion
        public static readonly DependencyProperty ScrolledLineProperty=
        DependencyProperty.RegisterAttached("ScrolledLine", typeof(int), typeof(Behaviors), new PropertyMetadata(ScrolledLine_Callback));
        // This callback will be invoked when 'ScrolledLine' property will be changed. Here you should scroll a textbox
        private static void ScrolledLine_Callback(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            var textbox = (TextBox) source;
            int newLineValue = (int)e.NewValue;
            if (newLineValue > 0 && newLineValue <= textBox.LineCount) // Validate
                textbox.ScrollToLine(newLineValue - 1); // Scroll to Line
        }
    }
