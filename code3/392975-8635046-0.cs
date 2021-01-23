    using System.Collections;
    public class Class : IEnumerable
    {
        // This method needn't implement any collection-interface method.
        public void Add(Student student) { ... }  
  
        IEnumerator IEnumerable.GetEnumerator() { ... }
    }
