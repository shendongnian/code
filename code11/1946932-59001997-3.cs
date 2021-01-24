    class BaseClass : System.IDisposable
    {
        public virtual void Dispose()
        {
            // never throw an exception from Dispose so prevent an NRE by using ?.
            this.IDisClassInstance?.Dispose();
        }
        //Private class that does not implement IDisposable
        private object NonIDisClassInstance;
        //Private class that does implement IDisposable
        private IDisposable IDisClassInstance;
    }
