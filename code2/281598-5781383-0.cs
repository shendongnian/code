    List<Tuple<MediaItem, DateTime>> list = new List<Tuple<MediaItem, DateTime>>();
    
     for (int i = 0; i <= 10; i++)
     {
          DateTime date = new DateTime(2011, i, 1);
          MediaItem item = new MediaItem();
          list.Add(new Tuple<MediaItem, DateTime>(item, date));
     }
    
    list.Sort((a, b) => a.Item2.CompareTo(b.Item2));
    
    foreach (var element in list)
    {
        Console.WriteLine(element);
    }
