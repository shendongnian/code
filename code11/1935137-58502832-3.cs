    public class FooB 
    { 
       FooA _a; 
    
       public FooB(FooA a) 
       { 
          // Pass instance of FooA to constructor 
          // (inject dependency) and store as a member variable
          this._a = a;
       } 
       
       public string PropertB { get; set; } 
    
       public void CanAccessFooA() 
       { 
           if (this._a != null)
              this._a.PropertyA = "See, I can access this here";
       } 
    }
