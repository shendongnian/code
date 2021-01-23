    public class Worker : MarshalByRefObject, IWorker
    {
        public void DoWork() 
        { 
            // Load the assembly here. This code will run in the AppDomain
        }
    }
    public interface IWorker
    {
        void DoWork();
    }
    public class Program
    {
        public static void Main()
        {
            AppDomain ad = AppDomain.CreateDomain("New domain");
            // This line creates a proxy to your worker.
            IWorker remoteWorker = (IWorker) ad.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName,
                "Worker");
            remoteWorker.DoWork();
            ad.Unload();
        }
    }
