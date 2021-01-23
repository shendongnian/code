    public abstract class Base : IBase
    >     {
    > 
    >         private IDep dep;
    > 
    >         [InjectionMethod]
    >         public void Initialize(IDep dep)
    >         {
    >             if (dep == null) throw new ArgumentNullException("dep");
    >             this.dep = dep;
    > 
    >             OnInitialize();
    >         }
    > 
    >         public dep DepProperty
    >         {
    >             get
    >             {
    >                 return dep;
    >             }
    >         }
    >         protected abstract void OnInitialize();
    >     }
    
    //now your Derived class Constructor will not be forced to have the IDep Parameter 
    class Derived : Base
    {
        public Derived()
        {
    
        }
    
        protected override void OnInitialize()
        {
            // you can access the baseclass dependency Instance in this override
            object depObject = this.DepProperty;
        }
    }
