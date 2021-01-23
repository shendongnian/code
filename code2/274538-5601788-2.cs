    abstract class Foo
    {
        public DateTime TimeCreated {get; private set;}
        protected Foo()
        {
             this.TimeCreated = DateTime.Now;
        }
    }
    abstract class Bar : Foo
    {
        public Bar() : base() //Bar's constructor's must call Foo's parameterless constructor.
        { }
    }
