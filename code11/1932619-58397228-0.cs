    public bool CheckUniqueName<T>(string newName, IEnumerable<T> items)
        where T : INamed
        => !items.Any(i => (i.Name == newName));
    public interface INamed
    {
        public Name { get; }
    }
    public class Planet : INamed
    {
        public Name { get; }
        public Plant(string name)
        { 
            Name = name;
        }
    }
    
    public class Colony : INamed
    {
        public Name { get; }
        public Colony(string name)
        { 
            Name = name;
        }
    }
