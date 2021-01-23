    class Parameters : IEnumerable
    {
        Dictionary<int, int> paramids;
        public Dictionary<int, int> addparam(int sid, int sbid)
        {
            if (paramids == null)
                paramids = new Dictionary<int, int>();
            paramids.Add(sid, sbid);
            return paramids;
        }
        IEnumerator<KeyValuePair<int, int>> GetEnumerator() 
        { 
            return paramids.GetEnumerator(); 
        }
    }
