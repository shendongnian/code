    public static void Loader
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += …;
            
            // We must switch to another class before attempting to use
            // any of the types in C:\ExtraAssemblies:
            Program.Go();
        }
        static Assembly FindAssem(object sender, ResolveEventArgs args)
        {
            string simpleName = new AssemblyName(args.Name).Name;
            string path = @"C:\ExtraAssemblies\" + simpleName + ".dll";
            if (!File.Exists(path)) return null;
            return Assembly.LoadFrom(path);
        }
    }
    public class Program
    {
        public static void Go()
        {
            // Now we can reference types defined in C:\ExtraAssemblies
        }
    }
