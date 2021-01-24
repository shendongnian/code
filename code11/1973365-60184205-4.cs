    public class AnotherDerivedClass : BaseClass
    {
        public bool IsValid => number == 10;
    }
    public class DerivedClass : BaseClass
    {   
        public void Print()
        {
            BaseClass anotherAsBase = new AnotherDerivedClass();
            anotherAsBase.number = 0;
        }
    }
