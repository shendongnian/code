    public class Artist
    {
         public string Name { get; set; }
         public Lazy<Manager> Manager { get; internal set; }
    }
