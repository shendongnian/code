    using System;
    using System.Threading;
    
    class Program {
        static void Main(string[] args) {
            var waits = new WaitHandle[65];
            for (int ix = 0; ix < waits.Length; ++ix) waits[ix] = new ManualResetEvent(false);
            WaitHandle.WaitAny(waits);
        }
    }
