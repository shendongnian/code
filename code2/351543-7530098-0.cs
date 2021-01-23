    class MyObjectComparer : IEqualityComparer<MyObject>
    {
         public bool Equals(MyObject x, MyObject y)
         {
              // implement appropriate comparison of x and y, check for nulls, etc 
         }
    
         public int GetHashCode(MyObject obj)
         {
              // validate if necessary
              return obj.KeyProperty.GetHashCode();
         }
    }
