    internal class InvariantChecker : IDisposable
    {
        private IContractObject obj;
        public InvariantChecker(IContractObject obj)
        {
            this.obj = obj;
        }
        public void Dispose()
        {
            if (Marshal.GetExceptionCode() != 0xCCCCCCCC && obj.CheckInvariants())
            {
                throw new ContractViolatedException();
            }
        }
    }
