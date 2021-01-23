    public class CustomControl1 : ComboBox
    {
            private Button clearButton;
            private ComboBox comboBox;
    
            static CustomControl1()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomControl1), new FrameworkPropertyMetadata(typeof(CustomControl1)));
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
    
                clearButton = GetTemplateChild("btn") as Button;
                comboBox = GetTemplateChild("comboBox") as ComboBox;
                clearButton.Click += new RoutedEventHandler(clearButton_Click);
            }
    
            private void clearButton_Click(object sender, RoutedEventArgs e)
            {
                comboBox.SelectedItem = null;
            }
    }
