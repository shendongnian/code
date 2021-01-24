    class Program {
        static void Main(string[] args) {
            // Getting current execution directory
            var currentExecutingPath = Assembly.GetExecutingAssembly().CodeBase;
            string dirtyDirectory = Path.GetDirectoryName(currentExecutingPath);
            string directory = dirtyDirectory.Replace(@"file:\", "");
            // Loading assembly in app context
            var externalAssembly = File.ReadAllBytes($"{directory}\\Mcs.ControlMaster.dll");
            AppDomain.CurrentDomain.Load(externalAssembly);
            // Now is loading. Creating an instance of class
            // The object type is "ObjectHandle"
            var hostTransportCommandInstance = Activator.CreateInstance("Mcs.ControlMaster", "Mcs.ControlMaster.HostTransportCommand");
            // Getting properties for validate instance creation
            // Using Unwrap() method we can access to true Type (HostTransportCommand)
            var hostTransportCommandType = hostTransportCommandInstance.Unwrap().GetType();
            var hostTransportCommandProperties = hostTransportCommandInstance.Unwrap().GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Showing information about type HostTransportCommand
            Console.WriteLine($"The type from Mcs.ControllerMaster is {hostTransportCommandType}");
            Console.WriteLine("Showing public properties (they was added for testing purposed):");
            foreach (PropertyInfo property in hostTransportCommandProperties) {
                Console.WriteLine(property.Name);
            }
            Console.ReadKey();
        }
    }
