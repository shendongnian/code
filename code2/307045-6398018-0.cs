    public class B : A 
    {  
        DateTime ValidFrom {get;set;} 
        DateTime? ValidTo {get;set;}
        public B(string code)
       {
       base.Code = code;
       } 
    }
