    class Base
    {
        protected Action m_action;
        public Base()
        {
            m_action = () => Console.WriteLine("Base Class");
        }
        public void NonVirtual()
        {
            m_action();
        }
    }
    
    class Derived : Base
    {
        public Derived()
        {
            m_action = () => Console.WriteLine("Derived Class");
        }
    }
    
    class Program
    {
        static void Main (string[] args)
        {
            Base baseClass = new Base();
            Derived derivedClass = new Derived();
            Base derivedAsBase = derivedClass;
            Console.WriteLine("Calling Base:");
            baseClass.NonVirtual();
            Console.WriteLine("Calling Derived:");
            derivedClass.NonVirtual();
            Console.WriteLine("Calling Derived as Base:");
            derivedAsBase.NonVirtual();
            Console.ReadKey();
        }
    }
