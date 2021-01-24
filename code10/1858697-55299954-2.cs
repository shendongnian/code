      public ObservableCollection<Data> ItemsSource { get; set; }
      public void AddItems()
      {
          ItemsSource.Add(new Data()); // not working
      }
