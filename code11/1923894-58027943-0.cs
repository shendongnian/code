        private readonly Dictionary<int, string> _data;
        public Tutorial()
        {
            _data = new Dictionary<int, string>;
        }
        public void setMethod(int id, string name)
        {
            _data.Add(id, name);
        }
        public String getMethod()
        {
            return _data[0];
        }
}
