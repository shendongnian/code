    using System;
    using System.Reflection;
    
    class Program {
        static void Main(string[] args) {
            if (args.Length > 0) Console.WriteLine(args[0]);
            else {
                Assembly asm = Assembly.LoadFrom(Assembly.GetEntryAssembly().Location);
                foreach (Type t in asm.GetTypes()) {
                    if (t.IsClass == true && t.FullName.EndsWith(".Program")) {
                        //object obj = Activator.CreateInstance(t);
                        object res = t.InvokeMember("Main",
                            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod,
                            null, null,
                            new object[] { new string[] { "Invoked" } });
                    }
                }
            }
        }
    }
