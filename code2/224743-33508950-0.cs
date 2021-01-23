    public class Aclass {        
        public int ReadOnly { get; set; }
    }
    
    public class Bclass : Aclass {        
        public new int ReadOnly { get; private set; }
    }
