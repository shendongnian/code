    public MyDerivedClass : ABC
    {
      public MyDerivedClass()
        : base(123) // hard wired default value for the base class
      {
        // Other things the constructor needs to do.
      }
      
      public override void computeA()
      {
        // Concrete definition for this method. 
      }
    }
