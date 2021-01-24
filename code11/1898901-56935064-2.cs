    private void RandomiseLines()
    {
        var rnd = new Random();
    
        Values = new ObservableCollection<double>();
    
        for (int i = 0; i < 3; i++)
        {
            Values.Add(rnd.Next(1, 300));
        }
    }
