    var playerCollection = new ObservableCollection<Player>();
    playerCollection.Add(new Player { Name = "Test 1" });
    playerCollection.Add(new Player { Name = "Test 2" });
    playerCollection.Add(new Player { Name = "Test 3" });
    playerDataGrid.ItemsSource = playerCollection;
            
