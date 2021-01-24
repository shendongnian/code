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
            private readonly IBaseConfig _config;
            protected WorkerFactory(IBaseConfig config)
            {
                this._config = config;
            }
            public virtual void Work()
            {
            }
            
        }
        public class Worker1 : WorkerFactory
    {
        private readonly IBaseConfig _config;
        public Worker1(IBaseConfig config):base(config)
        {
            _config = config;
        }
            
                public string test = "";
            
            public override void Work()
            {
                //do something
            }
        }
        public class Worker2 : WorkerFactory
    {
        private readonly IBaseConfig _config;
            
                public string test = "";
                public Worker2(IBaseConfig config):base(config)
                {
                    this._config = config;
                }
                public override void Work()
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
                worker.Work();
            }
        }
    }
