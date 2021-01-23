    public interface IProperty
    {
        public String Name { get; }
    }
    
    public class Property<T> : IProperty
    {
        public Property(String name, T value)
        {
            Name = name;
            Value = value;
        }
    
        public String Name { get; private set; }
        public T Value { get; private set; }
    
        public override String ToString()
        {
            return string.Format("{0}: {1}", base.Name, value)
        }
    }
