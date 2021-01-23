    abstract class A<T> where T:A
    {
        public event Action<T> Event1;
        public abstract void Method();
   
        public A(){Method();}
    }
    
    class B : A<B>
    {
        //has a field called Action<B> Event1;
        public void Method(){ //stuff }
    }
