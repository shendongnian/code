    class BaseClass
    {
       public virtual void Test(){
          Console.WriteLine("This is test of base class");
       }
    }
    
    class DerivedClass : BaseClass
    {
       public override void Test(){
          Console.WriteLine("This is test of derived class");
       }
    }
    
    class DerivedClass1 : BaseClass
    {
       public override void Test(){
          Console.WriteLine("This is test of derived class-1");
       }
    }
