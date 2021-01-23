    public class ObjectReader : IEnumerator<DataObject>
    {
        public bool MoveNext()
        {
           // try to read next file, return false if you can't
           // if you can, set the Current to the returned DataObject
        }
        public DataObject Current
        {
            get;
            private set;
        }
    }
