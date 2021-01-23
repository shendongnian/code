    public class baseClassAncestor{
    
    }
    public class baseOriginal:baseClassAncestor { 
        public string justAProperty; 
    } 
     
    public class baseSwapped:baseClassAncestor  { 
        public int sillyNumber; 
    } 
     
    public class derivedClass : baseOriginal { 
       public bool iAmDumb; 
    } 
