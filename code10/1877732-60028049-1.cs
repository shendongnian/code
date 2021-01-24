    namespace ConsoleApp
    {
        internal class Program
        {
            public static void Main(String[] args)
            {
                SeparateHosts();
            }
    
            private static Byte[] ReadAssemblyRaw()
            {
                // read Models class library raw bytes
            }
    
            private static void CrossAppDomain()
            {
                var isolationDomain = AppDomain.CreateDomain("Isolation App Domain");
    
                var isolationDomainLoadContext = (AppDomainBridge)isolationDomain.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "ConsoleApp2.AppDomainBridge");
                // person is MarshalByRefObject type for the current AppDomain
                var person = isolationDomainLoadContext.ExecuteFromAssembly(bytes);
            }
        }
    
    
        public class AppDomainBridge : MarshalByRefObject
        {
            public Object ExecuteFromAssembly(Byte[] raw)
            {
                var assembly = AppDomain.CurrentDomain.Load(rawAssembly: raw);
                dynamic person = assembly.CreateInstance("Models.Person");
                person.SayHelloFromAppDomain();
                return person;
            }
        }
    }
