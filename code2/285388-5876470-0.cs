    class NamedObject<T>
    {
        public readonly T Object;
        public readonly string Name;
        public NamedObject(string name, string value)
        {
            this.Object = value;
            this.Name = name;
        }
    }
