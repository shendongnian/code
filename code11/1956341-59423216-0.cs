    public class MyComboBox : ComboBox
    {
        public MyComboBox()
        {
            this.Loaded += MyComboBox_Loaded;
        }
    
        private void MyComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            TextSubmitted += MyComboBox_TextSubmitted;
        }
    
        private void MyComboBox_TextSubmitted(ComboBox sender, ComboBoxTextSubmittedEventArgs args)
        {
            var items = ItemsSource as ObservableCollection<UserRole>;
            if (items.Count > 0)
            {
                if (items.Any<UserRole>(s => s.name == args.Text))
                {
                    return;
                }
                else
                {
                    var newItem = new UserRole() { id = (items.Count + 1).ToString(), name = args.Text };
                    items.Add(newItem);
                }
    
            }
        }
    }
