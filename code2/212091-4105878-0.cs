    public class Foo<T> {
        public string Name {get;set;}
        private readonly List<T> items = new List<T>();
        public List<T> Items { get { return items; } }
    }
