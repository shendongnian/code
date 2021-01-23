            _items = new ObservableCollection<SomeClass>();
            _items.Add(new SomeClass() { Name = "a" });
            _items.Add(new SomeClass() { Name = "b" });
            _items.Add(new SomeClass() { Name = "c" });
            
            DataContext = _items;
        private void testButton_Click(object sender, RoutedEventArgs e)
        {
            _items.Add(new SomeClass(){Name = "ha"});
        }
