    class DayAttribute : Attribute
    {
        public string Name { get; private set; }
        public DayAttribute(string name)
        {
            this.Name = name;
        }
    }
