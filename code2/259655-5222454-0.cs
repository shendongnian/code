    internal class InvariantChecker : IDisposable
    {
        private IContractObject obj;
        public InvariantChecker(IContractObject obj)
        {
            this.obj = obj;
        }
        public bool Suppress { get; set; }
        public void Dispose()
        {
            if (!this.Suppress)
            {
                if (!obj.CheckInvariants())
                {
                    throw new ContractViolatedException();
                }
            }
        }
    }
    internal class Foo : IContractObject
    {
        private int DoWork()
        {
            using (var checker = new InvariantChecker(this))
            {
                try
                {
                    // do some stuff
                }
                catch
                {
                    checker.Suppress = true;
                    throw;
                }
            }
        }
    }
