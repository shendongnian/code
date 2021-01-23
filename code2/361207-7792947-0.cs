    public Base
    {
       public virtual void Register(object externalParam)
       {
           // base registration logic goes here
       }
    }
    
    public Registrator1: Base
    {
       public override void Register()
       {
           base.Register(null);
           // custom registration logic goes here
       }
    }
    
    public Registrator2: Base
    {
       public override void Register()
       {
           base.Register(null);
           // custom registration logic goes here
       }
    }
    
    public Registrator3: Base
    {
       public override void Register(object externalParam)
       {
           base.Register(externalParam);
           // custom registration logic goes here
       }
    }
