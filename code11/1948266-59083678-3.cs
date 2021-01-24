    public class myModel {
    
        public string name { get; set; }
    
        public string type { get; set; }
    
        public string imageUrl { get; set; }
    
        public List<myImage> images { get; set; }
        public myImage image;
    }
    
    public class myImage {
        public string src { get; set; }
    
    }
