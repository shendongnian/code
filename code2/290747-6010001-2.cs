    public class sdata
    {
        // other properties
        
        public likedatacollection likes { get; set; }
    
        public sdata()
        {
            likes = new likedatacollection();
        }
    }
    
    public class likedatacollection
    {
        public List<likesdata> data { get; set; }
    
        public likedatacollection()
        {
            data = new List<likesdata>();
        }
    }
