    public abstract class Class1
    {
        protected abstract void Method1();
        public abstract void Method2();
    }
    
    public class Class2 : Class1
    {
        protected override void Method1()
        { 
            //Class3 cannot call this.
        }
      
        public override void Method2()
        {
            //class 3 can call this.
        }
    }
    public class Class3 
    { 
        public void Method()
        {
            Class2 c2 = new Class2();
            c2.Method1(); //Won't work
            c2.Method2(); //will work
        }
    }
