        private dynamic _list;
        public List<T> GetList<T>()
        {
            return (List<T>)_list;
        }
        public void SetList<T>(List<T> list)
        {
            _list = list;
        }
        public string Name { get; set; }
    }
