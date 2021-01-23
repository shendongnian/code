      public class SomeClass<T> where T : class
      { 
        internal List<T> InternalList;
    
        public SomeClass() { InternalList = new List<T>(); }
    
        public void RemoveAll(T theValue)
        {
            //  this will work
            InternalList.RemoveAll(x => x == theValue);
        }
      }
