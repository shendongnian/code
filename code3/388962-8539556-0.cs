    public class SampleDataSource : IEnumerable<MyObject>
    {  
        public List<MyObject> Subjects { get; private set; }  
  
        public IEnumerator<MyObject> GetEnumerator()  
        {  
            return Subjects.GetEnumerator();
        }  
  
        IEnumerator IEnumerable.GetEnumerator()  
        {  
            return GetEnumerator();  
        }  
    }  
