    class Program
    {
        static void Main()
        {
            using (var hook = new MinHook())
            {
                // hook ExitProcess which is the Windows API underneath exit.
                var fake1 = hook.CreateHook<ExitProcess>("kernel32.dll", nameof(ExitProcess), Fake);
                hook.EnableHook(fake1);
                // on recent Windows, we must also hook CorExitProcess
                // because exit (defined in ucrtbased) always try it before calling ExitProcess
                // and if you only hook ExitProcess, the process hangs for some reason
                var fake2 = hook.CreateHook<CorExitProcess>("mscoree.dll", nameof(CorExitProcess), Fake);
                hook.EnableHook(fake2);
                CallExit();
                Console.ReadLine();
                hook.DisableHook(fake1);
                hook.DisableHook(fake2);
            }
        }
        static void Fake(int exitCode)
        {
            Console.WriteLine("Hmmm... nope, I want to live forever. Exit code: " + exitCode);
        }
        private delegate void ExitProcess(int uExitCode);
        private delegate void CorExitProcess(int uExitCode);
        [DllImport("MyDll.dll")]
        private static extern void CallExit();
    }
    
