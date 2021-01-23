    class Foo {
      private List<int> myList;
    
      public ReadOnlyCollection<int> ReadOnlyList {
         get {
             myList.AsReadOnly();
         }
      }
    }
