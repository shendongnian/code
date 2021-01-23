    public class Decorator : IMyInterface
    { 
         private readonly IMyInterface _next;
    
         public Decorator (IMyInterface next) { _next = next; }
    
         public override void Func1() { Pre(); _next.Func1; Post(); }
         public virtual void Func2() { Pre(); _next.Func2; Post(); }
    }
