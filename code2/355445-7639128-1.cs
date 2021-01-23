    abstract class Preference
    {
        protected abstract void Load();
        protected abstract void Save();
        public Preference()
        {
            Load();
        }
        ~Preference()
        {
            Save();
        }
    }
    class IntPreference : Preference
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
    class StringPreference : Preference
    {
        ...
    }
    class FloatPreference : Preference
    {
        ...
    }
