    public class DerivedClass : BaseClass
    {   
        public void Print()
        {
            BaseClass baseClass = new BaseClass();
            DerivedClass derived = new DerivedClass();
    
            // This is ok
            Console.WriteLine(number); 
    
            // So is this
            Console.WriteLine(derived.number);
    
            // But you can't do this
            Console.WriteLine(baseClass.number); 
        }
    }
