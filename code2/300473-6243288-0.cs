    class BaseClass{
    
        public virtual void Method(){
            Console.WriteLine("BaseClass");
        }
    }
    
    class SubClass : BaseClass{
        /* other properties, constructors, getters, setters etc. */
    
        public override void Method(){
            Console.WriteLine("SubClass");
        }
    }
    
    static class Test
    {
        public void go() {
            BaseClass instance = new SubClass();
            instance.Method(); // prints "SubClass"
        }
    }
