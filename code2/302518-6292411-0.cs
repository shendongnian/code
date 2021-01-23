    public ObservableCollection<Foo> Collection 
    { 
    get
        {
        return collection;
        }
     set
        {
        collection = value;
        OnPropertyChanged("Collection");
    
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            collection = new ObservableCollection<Foo>();
            //this.comboBox1.ItemsSource = collection;
            Foo f = new Foo("DSD");
            collection.Add(f);
            OnPropertyChanged("Collection");
        }
