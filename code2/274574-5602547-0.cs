    public abstract class Monitor
    {
        protected Stopwatch Timer = Stopwatch.StartNew();   
        public abstract void Run();
        public void Test()
        {
            Timer.Start();
            Run();
            Timer.End();
        }
    
    }
    
    public class Concrete : Monitor
    {
        public override void Run()
        {
            //DoSomething
        }
    }
