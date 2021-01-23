    public class Foo
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
    
        public class Foo(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
