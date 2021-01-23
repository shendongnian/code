    public class ProcessRunner : MarshalByRefbject, IProcessRunner
    {
        public void RunProcess(BasePerfTest bpf)
        {
            Console.WriteLine("CurrentAppDomain (WithinPR): {0}", Thread.GetDomain().Id);
        }
    }
