    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (var fs = new FileStream("OtherAssembly.dll", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var buffer = new byte[fs.Length];
                    // load my assembly into a byte array from disk
                    fs.Read(buffer, 0, (int) fs.Length);
    
                    // load the assembly in the byte array into the current app domain
                    AppDomain.CurrentDomain.Load(buffer);
                }
    
                // get my type from the other assembly that we just loaded
                var class1 = Type.GetType("OtherAssembly.Class1, OtherAssembly");
    
                // create an instance of the type
                var class1Instance = class1.GetConstructor(Type.EmptyTypes).Invoke(null);
    
                // find and invoke the HelloWorld method.
                var hellowWorldMethod = class1.GetMethod("HelloWorld");
                Console.WriteLine(hellowWorldMethod.Invoke(class1Instance, null));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
