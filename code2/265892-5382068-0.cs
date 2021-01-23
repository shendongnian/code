    using System.Runtime.CompilerServices;
    ...
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                // etc..
            }
            AvoidJitterBombing();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void AvoidJitterBombing() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmrPrincipal());
        }
