    class FooBase
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
    }
    class Foo : FooBase
    {
        public void SetId(int id) {}
        public void SetString(string name) {}
    }
    
