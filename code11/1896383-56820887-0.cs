    public class LocationTreeAlsTree : IEnumerable<SomeClass>
    {    
         public List<SomeClass> Something; // that is filled somewhere in class
    
         public IEnumerator<SomeClass> GetEnumerator()
         {
              return Something.GetEnumerator();
         }
    
         IEnumerator IEnumerable.GetEnumerator()
         {
              return GetEnumerator();
         }
    }
