    // Console app 
    class Program 
    {  
        public class AssemblyLoader : MarshalByRefObject
        {
            public void LoadAndCall(byte[] binary)
            {
                Assembly loadedAssembly = AppDomain.CurrentDomain.Load(binary);
                object[] tt = { 3, 6 };
                Type typ = loadedAssembly.GetType("SumLib.SumClass");
                MethodInfo minfo = typ.GetMethod("Sum", BindingFlags.Static | BindingFlags.Public);
                int x = (int)minfo.Invoke(null, tt);
                Console.WriteLine(x);
            }
        }
        static void Main()
        {
            AppDomain apd = AppDomain.CreateDomain("newdomain", AppDomain.CurrentDomain.Evidence, AppDomain.CurrentDomain.SetupInformation);
            FileStream fs = new FileStream("Sumlib.dll", FileMode.Open);
            byte[] asbyte = new byte[fs.Length];
            fs.Read(asbyte, 0, asbyte.Length);
            fs.Close();
            fs.Dispose();
            File.Delete("Sumlib.dll");    
            AssemblyLoader loader = (AssemblyLoader)apd.CreateInstanceAndUnwrap(typeof(AssemblyLoader).Assembly.FullName, typeof(AssemblyLoader).FullName);
            loader.LoadAndCall(asbyte);
            Console.ReadLine();
          }
    }  
