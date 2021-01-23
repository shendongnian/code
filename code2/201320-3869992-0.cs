    public ConcreteComponentA : IComponent
    {
      public virtual object Operation()
      {
        return new object();
      }
      public object AnotherOperation()
      {
        object a = this.Operation();
        // Do some other work
        return a;
      }
    }
    public CachingComponentA : ConcreteComponentA
    {
         public override object Operation()
         {
             if(!this.cache.Contains("key")
             {
                this.cache["key"] = base.Operation();
             }
             return this.cache["key"];
         }
    }
