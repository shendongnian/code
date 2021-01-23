    public class BaseClass
    {
        public BaseClass() 
        {
            Console.WriteLine("BaseClass constructor called..");
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass()
        {
            Console.WriteLine("DerivedClass constructor called..");
        }
    }
    DerivedClass obj = new DerivedClass();
    //Output
    //BaseClass constructor called..
    //DerivedClass constructor called..
