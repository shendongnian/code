    public class Countries
    {
        public Guid Id { get; set; } = Guid.NewGuid();
                                      //^^^^^^^^^^This was wrong in your code
        public string Name { get; set; }
    }
