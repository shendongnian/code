    using System;
    using System.Diagnostics;
    
    class CA : IDisposable
    {
        public void Dispose()
        {
            Debug.WriteLine("CA.Dispose");
        }
    }
    
    class CB : CA, IDisposable
    {
        public void Dispose()
        {
            Debug.WriteLine("CB.Dispose");
        }
    }
