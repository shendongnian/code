    public interface IPerson
    {
        string Name { get; }
    }
    public class Person : IPerson
    {
        public string Name { get; set; }
    }
