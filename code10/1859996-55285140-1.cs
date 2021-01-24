    public interface IHasId
    {
        int Id { get; set; }
    }
    
    public class SomeEntity : IHasId
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //etc
    }
