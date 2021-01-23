    public abstract class Generic_T
    {
        public string Firstname {get; set;}
        public string  Lastname {get; set;}
        public int ID {get; set;}
    }
    
    public class A : Generic_T
    { 
        public int xxx {get; set}   // only in class A
        public int yyy{get; set}    // only in class A
        ... 
    }
    
    public class B : Generic_T
    { 
        public int aaa {get; set}   // only in class B
        public int bbb {get; set} // only in class B
        ... 
    }
    
    public class C : Generic_T
    { 
        public int kkk {get; set}   // only in class C
        public int ppp {get; set} // only in class C
        ...
    }
