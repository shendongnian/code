    class TitleColorEqualityComparer : IEqualityComparer<Item>
    {
         public bool Equals(Item a, Item b) 
         {
              // you might also check for nulls here
              return a.Title == b.Title && 
                  a.Color == b.Color;
         }
         public int GetHashCode(Item obj)
         {
              // this should be as much unique as possible,
              // but not too complicated to calculate
              int hash = 17;
              hash = hash * 31 + obj.Title.GetHashCode();
              hash = hash * 31 + obj.Color.GetHashCode();
              return hash;
         }
    }
