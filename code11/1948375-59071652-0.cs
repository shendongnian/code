    public interface IMedia
    {
        public int Order;
    }
    
    public class Video : IMedia
    {
       public string URL { get; set; }
       public int Order { get; set; }
    }
    
    public class Image : IMedia
    {
        public string Name { get; set; }
        public int Order { get; set; }
    }
