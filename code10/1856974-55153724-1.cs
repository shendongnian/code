    public class List : IEnumerable
    {
        object[] _objects;
 
        public List()
        {
            _objects = new object[100];
        }
        //Other code of List class.
        public IEnumerator GetEnumerator()
        {
           return new ListEnumerator(this);
        }
    }
