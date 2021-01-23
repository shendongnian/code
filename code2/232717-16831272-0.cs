        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            if (args.Name.Equals("MyFullAssemblyName")) {
                var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                if (IntPtr.Size > 4) {
                    var dll = System.IO.Path.Combine(path, @"MySubDir\MyDLL_x64.dll");
                    return System.Reflection.Assembly.LoadFile(dll);
                }
                else {
                    var dll = System.IO.Path.Combine(path, @"MySubDir\MyDLL.dll");
                    return System.Reflection.Assembly.LoadFile(dll);
                }
            }
            return null;
        }
