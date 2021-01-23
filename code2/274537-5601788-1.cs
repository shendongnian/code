    abstract class Foo
    {
        public DateTime TimeCreated {get; private set;}
        protected foo()
        {
             this.TimeCreated = DateTime.Now;
        }
    }
    abstract class Bar
    {
        public Bar() : base() //Bar's constructor's must call Foo's parameterless constructor.
        { }
    }
