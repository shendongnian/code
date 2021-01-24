    public class Person : Base
    {
        public Person() : base(MyEnum.Person)
        {
            // this will be executed after the base constructor completes
        }
    }
