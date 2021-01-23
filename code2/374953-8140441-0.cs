    class A 
    {
       public virtual string TestString { get; set; }
    }
    
    class B : A
    {
       public override string TestString
       {
          get { return "x"; }
       }
    }
