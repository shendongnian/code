    class ValList
    {
        private Action<string>[] _setters;
    
        public ValList(params Action<string>[] refs)
        {
            _setters = refs;
        }
    
        internal void SetFrom(string[] values)
        {
            for (int i = 0; i < values.Length && i < _setters.Length; i++)
                _setters[i](values[i]);
        }
    }
