    public class IndexedObject
    {
        private object _rootObject;
        private int _index;
        public IndexedObject(object rootObject, int index)
        {
            _rootObject = rootObject;
            _index=index;
        }
        public string Value
        {
            get
            {
                return _rootObject.ToString();
            }
        }
        public int Index
        {
            get
            {
                return _index;
            }
        }
    }
