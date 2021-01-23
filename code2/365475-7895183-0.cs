    using System;
    
    public interface IFoo
    {
        void Foo();
    }
    
    public class Base : IFoo
    {
        void IFoo.Foo()
        {
            Console.WriteLine("Base");
        }
    }
    
    public class Derived : Base, IFoo
    {
        void IFoo.Foo()
        {
            Console.WriteLine("Derived");
        }
    }
    
    class Test
    {
        static void Main()
        {
            var map = typeof(Base).GetInterfaceMap(typeof(IFoo));            
            var method = map.TargetMethods[0]; // There's only one method :)
            method.Invoke(foo, null);
        }
    }
