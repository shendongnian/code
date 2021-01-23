    class Parameters:IEnumerable<KeyValuePair<int,int>>
    {
        Dictionary<int, int> paramids;
    
        public Parameters AddParam(int sid, int sbid)
        {
            if (paramids == null)
                paramids = new Dictionary<int, int>();
            paramids.Add(sid, sbid);
            return this;
        }
    
        public IEnumerator<KeyValuePair<int,int>> GetEnumerator()
        {
            return paramids.GetEnumerator();
        }
    
        object IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
