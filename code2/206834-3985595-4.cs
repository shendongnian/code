    public class Derived : BaseClass
    {
        new public void xyz()
        {
            Console.WriteLine("In Derived Class");
        }
    }
    public class BaseClass : Intfc
    {
    
        public void xyz()
        {
            Console.WriteLine("In Base Class");
        }
    }
