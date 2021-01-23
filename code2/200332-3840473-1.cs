    class SomeComponent
    {
      [Browsable(true)]
      public virtual string SomeInfo{get;set;}
    }
    
    class SomeOtherComponent : SomeComponent
    {
      [Browsable(false)]  // this property should not be browsable any more
      public override string SomeInfo{get;set;}
    }
