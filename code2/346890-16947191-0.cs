    public class Person
    {
        string Name { get; set; }
        string Path { get; set; }
    
        public override string ToString()
        {
            return Name + ": " + Path;
        }
    }
