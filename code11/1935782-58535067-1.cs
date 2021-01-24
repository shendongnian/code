    public class Header
    {
        public int HeaderId { get; set; } // The primary key of the Header table
        public string Code { get; set; } // Foreign key of the Detail table
    
        // various Header data
         public Color btnColor { get; set; }
    
    }
