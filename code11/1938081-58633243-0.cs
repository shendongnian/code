     namespace CoreApp1
     {
        public class ConfigSectionItem
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
                var configuration = configBuilder.Build();
                var confList = new List<ConfigSectionItem>();
                configuration.GetSection("Sections").Bind(confList);
                foreach (var confItem in confList)
                {
                    var typeToBuild = Type.GetType($"CoreApp1.{confItem.Type}"); // Remember to do some checks with typeToBuild (not null, ...)
                    var newInstance = (BaseSection)Activator.CreateInstance(typeToBuild);
                    newInstance.Name = confItem.Name; // Use automapper or reflexion
                    // do what you want here with your newInstance
                    Console.WriteLine(newInstance.GetType().FullName + " " + newInstance.Name);
                }
            }
        }
        public abstract class BaseSection
        {
            public string Name;
        }
        public class Type1 : BaseSection
        {
        }
        public class Type2 : BaseSection
        {
        }
     }
