    public class Dog
    {
        public int? Age { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float? Weight { get; set; }    
    }            
                
    var guid = Guid.NewGuid();
    var dog = connection.Query<Dog>("select * from Dogs where Id = @Id",
        new { Id = 42 }
    ).First();
            
