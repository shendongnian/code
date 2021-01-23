    abstract class N<T> 
    {
        public abstract void foo(T a);
    }
    
    class B : N<int>
    {
        public override void foo(int a)
        {              
        }
    }
