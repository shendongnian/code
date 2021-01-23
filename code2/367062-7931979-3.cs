    class ConfigurationItem
    {
        public string override ToString()
        {
            return string.Format("{0}: {1}\n", Name, Value);
        }
    }
    class OptionalItem
    {
        public string override ToString()
        {
            return string.Format("{0}, ", Name);
        }
    }
