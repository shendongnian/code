    class MyClass
    {
        private Hashtable MyProperties { get; set; }
        public object GetProperty(string name)
        {
            return MyProperties.Contains(name) ? MyProperties[name] : null;
        }
        public void SetProperty(string name, object value)
        {
            if (MyProperties.Contains(name))
                MyProperties[name] = value;
            else
                MyProperties.Add(name, value);
        }
    }
