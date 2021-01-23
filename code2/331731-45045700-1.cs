     public class Acessor
    {
        Dictionary<string, object> myElements = new Dictionary<string, object>();
        public object this[string key]
        {
            get
            {
                return myElements[key];
            }
            set
            {
                myElements.Add(key, value);
            }
        }
    }
