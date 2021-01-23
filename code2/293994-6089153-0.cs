    class Loader {
        static void Main()
        {
             // not shown: register assemy-load here
             MainCore();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void MainCore()
        {   // your class as shown is Program
            Program.Init();
        }
    }
