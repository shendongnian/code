    class Program {
        private class NonSerializableException : Exception { }
        static void Main(string[] args) {
            var childAppDomain = AppDomain.CreateDomain("Child");
            Console.WriteLine("Created child AppDomain #{0}.", childAppDomain.Id);
            // I did not create a new assembly for the helper class because I am lazy :)
            var helperAssemblyLocation = typeof(AppDomainHelper).Assembly.Location;
            var helper = (AppDomainHelper)childAppDomain.CreateInstanceFromAndUnwrap(
                    helperAssemblyLocation, typeof(AppDomainHelper).FullName);
            helper.Initialize(UnloadHelper.Instance);
            childAppDomain.DoCallBack(
                () => new Thread(delegate() { throw new NonSerializableException(); }).Start());
            Console.ReadLine();
        }
        private sealed class UnloadHelper : MarshalByRefObject, IAppDomainUnloader {
            public static readonly UnloadHelper Instance = new UnloadHelper();
            private UnloadHelper() { }
            public override object InitializeLifetimeService() {
                return null;
            }
            public void RequestUnload(int id) {
                // Add application domain identified by id into unload queue.
                Console.WriteLine("AppDomain #{0} requests unload.", id);
            }
        }
    }
    // These two types could be in another helper assembly
    public interface IAppDomainUnloader {
        void RequestUnload(int id);
    }
    public sealed class AppDomainHelper : MarshalByRefObject {
        public void Initialize(IAppDomainUnloader unloader) {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
                    unloader.RequestUnload(AppDomain.CurrentDomain.Id);
        }
    }
