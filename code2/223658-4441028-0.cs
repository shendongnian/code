    public class MyDatePicker : DatePicker
    {
        public MyDatePicker()
        { }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            DatePickerTextBox textBox = (DatePickerTextBox)this.GetTemplateChild("TextBox");
            textBox.GotFocus += new RoutedEventHandler(textBox_GotFocus);
            textBox.LostFocus += new RoutedEventHandler(textBox_LostFocus);
        }
        void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            (sender as DatePickerTextBox).BorderBrush = new SolidColorBrush(Colors.Red);
        }
        void textBox_LostFocus(object sender, RoutedEventArgs e)
        {
            (sender as DatePickerTextBox).ClearValue(DatePickerTextBox.BorderBrushProperty);
        }
    }
