      public ReadOnlyCollection<Item> MyROList {
        get { return new ReadOnlyCollection<Item>(myList); }
      }
    
      private List<Item> myList = new List<Item>();
