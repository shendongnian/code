    class Preference
    {
        protected abstract void Load();
        protected abstract void Save();
        public Preference()
        {
            Load();
        }
        public ~Preference()
        {
            Save();
        }
    }
    class IntPreference
    {
        protected override void Load()
        {
            //load from registry or config file
        }
        protected override void Save()
        {
            //save to registry or config file
        }
        public int Value { get; set; }
    }
    class StringPreference
    {
        ...
    }
    class FloatPreference
    {
        ...
    }
