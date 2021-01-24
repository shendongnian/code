    class Foo : EntityBase<string>
    {
        public Foo(string id) : base(id) { }
    }
    
    class Bar : EntityBase<int>
    {
        public Bar(int id) : base(id) { }
    }
    class FooRepository : Repository<string, Foo>
    {
        public FooRepository() { }
    }
    
    class BarRepository : Repository<int, Bar>
    {
        public BarRepository() { }
    }
