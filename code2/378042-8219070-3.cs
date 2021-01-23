    public class Worker : MarshalByRefObject
    {
        public void DoWork() 
        { 
            // Load the assembly here. This code will run in the AppDomain
        }
    }
    public class Program
    {
        public static void Main()
        {
            AppDomain ad = AppDomain.CreateDomain("New domain");
            // This line creates a proxy to your worker.
            Worker remoteWorker = (Worker) ad.CreateInstanceAndUnwrap(
                Assembly.GetExecutingAssembly().FullName,
                "Worker");
            remoteWorker.DoWork();
        }
    }
