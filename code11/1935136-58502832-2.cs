    public class FooA 
    {
       public string PropertyA { get; set; }
    }
    
    public class FooB 
    { 
       public string PropertyB { get; set; } 
    
       public void CanAccessFooA(FooA a) 
       { 
           a.PropertyA = "See, I can access this here";
       } 
    }
