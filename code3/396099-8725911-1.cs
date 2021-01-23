    public class Setting<T> 
    {
        public Setting<T>(string name, T value)
        { 
            Name = name;
            Value = value;
        } 
        public string Name { get; set; }
        public T Value { get; set; }
    }
