    using System;
    using System.Runtime.CompilerServices;
    
    class Program {
        static void Main(string[] args) {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            DelayedMain(args);
        }
    
        [MethodImpl(MethodImplOptions.NoInlining)]
        static void DelayedMain(string[] args) {
            // etc..
        }
    
    
        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            // etc...
        }
    }
