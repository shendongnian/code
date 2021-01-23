    abstract class A<T>
    {
        protected static T myValue;
    }
    
    class B : A<long>
    {
        static B()
        {
            myValue = 2;
        }
    }
    
    class C : A<int>
    {
        static C()
        {
            myValue = 3;
        }
    }  
