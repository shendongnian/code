    public class InnerDictionary : Dictionary<int, string>
    {
    }
    
    public class OuterDictionary : Dictionary<int, InnerDictionary>
    {
        public new InnerDictionary this[int key]
        {
            get
            {
                if (!base.ContainsKey(key))
                {
                    base.Add(key, new InnerDictionary());
                }
    
                return base[key];
            }
    
            set { throw new NotSupportedException("Message"); }
        }
    }
