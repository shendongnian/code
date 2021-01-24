    public interface IHello
    {
        void Hello();
    }
    
    public class Zero: IHello
    {
        public void Hello()
        {
        }
    //...
    }
    
    ...
    
    void RunHelloIfPossible(object obj)
    {
       if (obj is IHello ih)
       {
          ih.Hello();
       }
    }
