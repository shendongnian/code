    public class Base
    {
        private readonly MyEnum _classType;
        public Base(MyEnum classType)
        {
            _classType = classType;
        }
        protected Base()
        {
            _classType = classType.Derived;
        }
    }
    public class Person : Base
    {
        public Person() : base()
        {
            // this will be executed after the base constructor completes
        }        
    }
