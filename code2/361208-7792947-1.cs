    public class Base
    {
       public virtual void Register(object externalParam)
       {
           // base registration logic goes here
       }
    }
    
    public class Registrator1: Base
    {
       public override void Register(object externalParam)
       {
           base.Register(null);
           // custom registration logic goes here
       }
    }
    
    public class Registrator2: Base
    {
       public override void Register(object externalParam)
       {
           base.Register(null);
           // custom registration logic goes here
       }
    }
    
    public class Registrator3: Base
    {
       public override void Register(object externalParam)
       {
           base.Register(externalParam);
           // custom registration logic goes here
       }
    }
