    class NameCollection : /* whatever */
    {
        private List<string> _names = new List<string> { "Ed", "Sally", "John" };
    
        public string this[int index]
        {
            get { return _names[index]; }
        }
    }
