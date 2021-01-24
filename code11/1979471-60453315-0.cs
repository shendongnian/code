    public class User
    {
       public int Id {get; set;}
       public string Name{get; set;}
       public List<Picture> Pictures{get; set;}
    }
    
    public class Picture
    {
        public string Id {get; set;}
        public string Url{get; set;}
        public byte[] Image{get; set;}
    }
