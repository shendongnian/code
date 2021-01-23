    public abstract class Base
    {
        public override int GetX(int arg)
        {
            if(arg < 0) return 0;
            return OnGetX(arg);
        }
    
        protected abstract OnGetX(int arg);
    }
    
    public class MyClass : Base
    {
        protected override int OnGetX(int arg)
        {
            return arg * 2;
        }
    }
    
    MyClass x = new MyClass();
    Console.WriteLine(x.GetX(5));    // prints 10
    Console.WriteLine(x.GetX(-3));   // prints 0
