If you want to load DLLs, you can combine the above with the AppDomain.AssemblyResolve event SLaks mentions like this:
    using System.IO;
    using System.Reflection;
    namespace ConsoleApplication3
    {
      class Program
      {
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.AssemblyResolve += 
                    new ResolveEventHandler(MyResolveEventHandler);
            var myWrappedClass1 = 
                currentDomain.CreateInstance(
                        "ConsoleApplication3.ClassLibrary1.dll", 
                        "ClassLibrary1.Class1");
            var myClass1 = myWrappedClass1.Unwrap();
            Console.WriteLine(myClass1.GetType().InvokeMember(
                        "Add", 
                        BindingFlags.Default | BindingFlags.InvokeMethod, 
                        null,
                        myClass1, 
                        new object[] { 1, 1 }));
            Console.ReadLine();
        }
        private static Assembly MyResolveEventHandler(
                object sender, ResolveEventArgs args)
        {
            Assembly currentAssembly=null;
            Stream dllStream;
            try
            {
                currentAssembly = Assembly.GetExecutingAssembly();
                dllStream = 
                        currentAssembly.GetManifestResourceStream(args.Name);
                var length = (int)dllStream.Length;
                var dllByteArray = new byte[length];
                int bytesRead;
                int offset = 0;
                while ((bytesRead = dllStream.Read(
                                        dllByteArray, 
                                        offset, 
                                        dllByteArray.Length - offset)) 
                        > 0)
                    offset += bytesRead;
                return Assembly.Load(dllByteArray);
            }
            catch
            {
                Console.WriteLine("Error accessing resources!");
            }
            return null;
        }
      }
    }
where Class1 is a class library containing just:
    namespace ClassLibrary1
    {
        public class Class1
        {
            public int Add(int x, int y)
            {
                return x + y;
            }
        }
    }
