    interface IFoo
    {
         void M();
    }
    
    interface IBar
    {
         void X(); 
    }
    
    public class Bar : IBar, IFoo
    {
        public void X() // part of the public API of Bar
        {
        }
    
        void IFoo.M() // only visisible via IFoo
        {
        }
    }
