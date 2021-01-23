    class Program
    {
        static void Main(string[] args)
        {
            Inherited obj = new Inherited("Alpha");
            obj.test();
            Inherited1 obj1 = new Inherited1(); //This will fail as there is no ctor with single param.
            obj1.test();
        }
    }
    public class MyBase
    {
       public MyBase()
       {
          if(!ValidateConstructorLogic())
          {
              throw new ApplicationException("Expected consturctor with single argument");
          }
       }
    
        public bool ValidateConstructorLogic()
        {
            bool ValidCtorFound = false;
    
            foreach (var info in this.GetType().GetConstructors())
            {
                if(info.GetParameters().Length ==1)
                    ValidCtorFound = true;
            }
    
            return ValidCtorFound;
        }
    }
    
    public class Inherited:MyBase
    {
        public Inherited(string test)
        {
            Console.WriteLine("Ctor");
        }
    
        public void test()
        {
            Console.WriteLine("TEST called");
        }
    }
    public class Inherited1 : MyBase
    {
        public void test()
        {
            Console.WriteLine("TEST called");
        }
    }
