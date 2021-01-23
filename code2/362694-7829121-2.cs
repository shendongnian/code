    public class ProcessRunner : MarshalByRefbject
    {
        public void RunProcess(BasePerfTest bpf)
        {
            Console.WriteLine("CurrentAppDomain (WithinPR): {0}", Thread.GetDomain().Id);
        }
    }
