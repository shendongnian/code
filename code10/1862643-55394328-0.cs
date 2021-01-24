    public class Entity
    {
        public Guid Id { get; set; }
        [MustBeUnique]
        public string Name { get; set; }
        [MustBeUnique]
        public string Surname { get; set; }
    }
