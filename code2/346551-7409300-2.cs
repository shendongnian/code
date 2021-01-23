    public class Person
    {
        public string Name { get; set; }
        public Person Parent { get; set; }
        public IList<Person> Children { get; private set; }
    
        public Person()
        {
            Children = new List<Person>();
        }
    
        public void Add(Person child)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }
