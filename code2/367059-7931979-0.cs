    class Configuration
    {
        public string override ToString()
        {
            return string.Format(formatProvider, "{0}: {1}\n", Name, Value);
        }
    }
    class Optional
    {
        public string override ToString()
        {
            return string.Format(formatProvider, "{0}, \n", Name);
        }
    }
