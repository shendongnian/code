    public class MyModel : ObjectContext
    {
        public MyModel(EntityConnection connection) : base(connection) { DefaultContainerName = "MyModel"; }    
        
        public IObjectSet<Template> Template { get { return base.CreateObjectSet<Template>(); } }    
        
        public IObjectSet<Influence> Influence { get { return base.CreateObjectSet<Influence>(); } }    
        
        public IObjectSet<Trait> Trait { get { return base.CreateObjectSet<Trait>(); } }
    }
