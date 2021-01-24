    public abstract class BaseClass
    {
        public void DoMe()
        {
            using (new UseSomething())
            {
                ActualDoMe();
            }
        }
        protected abstract void ActualDoMe();
    }
    public class Der : BaseClass
    {
        protected override void ActualDoMe()
        {
            Console.WriteLine("der do me");
        }
    }
