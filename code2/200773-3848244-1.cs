    class Item : IComparable<Item> { 
      public string Loc { get; private set; }
      public Item(Field[] fields) {
        Loc = // logic to get value of 'Loc'
        // Load all other values
      }
      public int CompareTo(Item other) {
        int res = Loc.CompareTo(other.Loc);
        if (res != 0) return res; 
        // .. compare other fields
      }
    }
