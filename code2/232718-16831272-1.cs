        static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
            if (args.Name.Equals("MyFullAssemblyName")) {
                var ass = Assembly.GetExecutingAssembly();
                if (IntPtr.Size > 4) {
                    var strm = ass.GetManifestResourceStream("the.resource.name.for.MyDLL_x64.dll");
                    var data = new byte[strm.Length];
                    strm.Read(data, 0, data.Length);
                    return Assembly.Load(data);
                }
                else {
                    var strm = ass.GetManifestResourceStream("the.resource.name.for.MyDLL.dll");
                    var data = new byte[strm.Length];
                    strm.Read(data, 0, data.Length);
                    return Assembly.Load(data);
                }
            }
            return null;
        }
