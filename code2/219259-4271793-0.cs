    using System;
    using System.Reflection;
    
    class Program
    {
        static void Main(string[] args)
        {
            DumpFilenameForType(typeof(A));
            DumpFilenameForType(typeof(B));
    
            if (System.Diagnostics.Debugger.IsAttached)
            {
                System.Console.Write("Press any key to continue . . . ");
                System.Console.ReadKey();
            }
        }
    
        static void DumpFilenameForType(Type t)
        {
            MethodInfo mi = t.GetMethod("_GetSourceFileName", BindingFlags.Static | BindingFlags.NonPublic);
            if (mi != null)
                Console.WriteLine("Type '{0}' is located in '{1}'", t.FullName, mi.Invoke(null, null));
            else
                Console.WriteLine("Type '{0}' does not provide method _GetTranslationUnit", t.FullName);
        }
    }
