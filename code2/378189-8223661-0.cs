    class Program
    {
        static void Main(string[] args)
        {
            var asmFileName = "test.dll"; // Your plug-in file name
            var asmPath = AppDomain.CurrentDomain.BaseDirectory; // Your assemblies's root folder
            var asmFullPath = System.IO.Path.Combine(asmPath, asmFileName);
            var asm = System.Reflection.Assembly.LoadFrom(asmFullPath);
        }
    }
