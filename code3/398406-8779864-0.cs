    public abstract class Worker
    {    
        public abstract void ProcessJob();
    }
    
    public class PizzaWorker : Worker
    {
        public override void ProcessJob()
        {
            // Make pizza
        }
    }
    
    public class BurgerWorker : Worker
    {
        public override void ProcessJob()
        {
            // Make burger
        }
    }
