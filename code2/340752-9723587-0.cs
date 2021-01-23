    public class AssemblyResolver
    {
        public static void HandleUnresovledAssemblies()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += currentDomain_AssemblyResolve;
        }
        private static Assembly currentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name == "System.Data.SQLite")
            {
                var path = Path.Combine(pathToWhereYourNativeFolderLives, "Native");
                if (IntPtr.Size == 8) // or for .NET4 use Environment.Is64BitProcess
                {
                    path = Path.Combine(path, "64");
                }
                else
                {
                    path = Path.Combine(path, "32");
                }
                path = Path.Combine(path, "System.Data.SQLite.DLL");
                Assembly assembly = Assembly.LoadFrom(path);
                return assembly;
            }
            return null;
        }
    }
