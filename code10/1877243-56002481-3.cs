    public class BaseClass
    {
        public virtual void DoMe()
        {
            using(new UseSomething())
            {
               // do the real base-stuff
            }
        }
    }    
    public class Der : BaseClass
    {
        public override void DoMe()
        {
            base.DoMe(); // now there´s no endless recursion
            // some additional stuff
        }
    }
