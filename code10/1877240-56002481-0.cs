    public class BaseClass
    {
        public virtual void DoMe()
        {
            using(new UseSomething())
            {
                //invoke the derived method body
            }
        }
    }
    public class Der : BaseClass
    {
        public override void DoMe()
        {
            base.DoMe(); // this would call the base-method which will then call this metghod ...
        }
    }
