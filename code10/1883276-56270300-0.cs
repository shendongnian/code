    public class Dog
    {
        public string Name { get; set; }
        public float? Weight { get; set; }    
    }
    
    var dog = connection.Query<Dog>("SOME QUERY", new { Name = "DOGNAME" });
