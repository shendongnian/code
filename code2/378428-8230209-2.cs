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
    
        void IFoo.M() // explicit implementation, only visible via IFoo
        {
        }
    }
    Bar bar = new Bar();
    bar.X(); // visible
    bar.M(); // NOT visible, cannot be invoked
    IFoo foo = bar;
    foo.M(); // visible, can be invoked
