    class Wrapper : DictionaryBase
    {
        public List<Person> this[string key]
        {
            get
            {
                return this[key];
            }
        }
    }
