    public class BaseClass
    {
        public virtual void DoSomething() {  }
        public virtual void DoMe()
        {
            using(new UseSomething())
            {
               DoSomething();  // this will call the most derived member, in our case Der.DoSomething
            }
        }
    }    
    public class Der : BaseClass
    {
        public override void DoSomething()
        {
            // some additional stuff
        }
        public override void DoMe()
        {
            Console.WriteLine("Der do me");
        }
    }
