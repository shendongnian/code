    System.Collections.ObjectModel.ObservableCollection<int> coll = 
        new System.Collections.ObjectModel.ObservableCollection<int>()
            { 1, 2, 3, 4, 5 };
    foreach (var i in coll.Skip(2).Take(2))
    {
        Console.WriteLine(i);
    }
