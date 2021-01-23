    public class objFiveProp
    {
        private Dictionary<string, int> _items;
        public int this[string key]
        {
            get { return _items[key]; }
            set { _items[key] = value; }
        }
        public int Index1 
        {
            get { return this["index1"]; } 
            set { this["index1"] = value; }
        }
        public int Index2
        {
            get { return this["index2"]; } 
            set { this["index2"] = value; }
        }
        // ....
        public objFiveProp()
        {
            _items = new Dictionary<string, int>();
            _items.Add("index1", index1);
            _items.Add("index2", index2);
            _items.Add("index3", index3);
            _items.Add("index4", index4);
            _items.Add("index5", index5);    
        }
    #endregion
