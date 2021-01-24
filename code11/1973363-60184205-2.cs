    public class AnotherDerivedClass : BaseClass { }
    public class DerivedClass : BaseClass
    {   
        public void Print()
        {
            BaseClass anotherAsBase = new AnotherDerivedClass();
            Console.WriteLine(anotherAsBase.number);
        }
    }
