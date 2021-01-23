    public static class ObservableCollectionExtension
    {
      public static ObservableCollection<T> Load<T>(this ObservableCollection<T> Collection, List<T> Source)
      {
              Collection.Clear();    
              Source.ForEach(x => Collection.Add(x));    
              return Collection;
       }
    }
