    class FooBase
    {
        public int ID { get; protected set; }
        public string Name { get; protected set; }
    }
    class Foo : FooBase
    {
        public void SetId(int id) { /* ... */ }
        public void SetString(string name) { /* ... */ }
    }
    
