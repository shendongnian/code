    namespace DocumentHandler
    {
        public interface IBaseConfig
        {
        }
        public class ConfiManager : IBaseConfig
    {
    }
        public abstract class WorkerFactory
        {
            public virtual void Work(IBaseConfig options)
            {
            }
            
        }
        public class Worker1 : WorkerFactory
    {
        private readonly IBaseConfig _config;
        public Worker1(IBaseConfig config)
        {
            _config = config;
        }
            
                public string test = "";
            
            public override void Work(IBaseConfig op)
            {
                //do something
            }
        }
        public class Worker2 : WorkerFactory
    {
        private readonly IBaseConfig _config;
            
                public string test = "";
                public Worker2(IBaseConfig config)
                {
                    this._config = config;
                }
                public override void Work(IBaseConfig options)
            {
                Console.WriteLine("Hello world");
            }
        }
        public class Test
        {
            public static IBaseConfig config = new ConfiManager(); 
            public static void test()
            {
                WorkerFactory worker =
                    (Worker2) Activator.CreateInstance(Type.GetType("DocumentHandler.Worker2"), config);
                worker.Work(config);
            }
        }
    }
   
