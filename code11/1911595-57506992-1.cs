    public class MyClass
    {
        public string Name { get; set; }
        public List<string> MyList { get; set; }
        public Control MyControl
        {
            get
            {
                return GetControlForName();
            }
        }
        Control GetControlForName()
        {
            if (Name == "textbox")
            {
                var textBox = new TextBox();
                Binding binding = new Binding(nameof(Name));
                binding.Source = this;
                textBox.SetBinding(TextBox.TextProperty, binding);
                return textBox;
            }
            else if (Name == "combobox")
            {
                var comboBox = new ComboBox();
                comboBox.ItemsSource = MyList;
                return comboBox;
            }
            {
                return null;
            }
        }
    }
