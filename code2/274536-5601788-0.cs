    abstract class Foo
    {
        public DateTime TimeOfInstantiation {get; private set;}
        protected foo()
        {
             this.TimeOfInstantiation = DateTime.Now;
        }
    }
    abstract class Bar
    {
        public Bar() : base() //Bar's constructor's must call Foo's parameterless constructor.
        { }
    }
