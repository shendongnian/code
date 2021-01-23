    class EntityBase
    {
        public int Id { get; protected set; }
        // tood: implement compare logic
    }
    class Foo : EntityBase
    {
        public string Name { get; set; }
    }
