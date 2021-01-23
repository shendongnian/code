    public static class ConfigurationManagerHelper
    {
        public static bool Exists()
        {
            return Exists(System.Reflection.Assembly.GetEntryAssembly());
        }
    
        public static bool Exists(Assembly assembly)
        {
            return System.IO.File.Exists(assembly.Location + ".config" )
        }
    }
