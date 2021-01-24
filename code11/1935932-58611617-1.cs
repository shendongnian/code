    using Scrutor;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    namespace Microsoft.Extensions.DependencyInjection
    {
        public static class DotNetCoreBootstrapper
        {
            public static void AddSolutionServices(this IServiceCollection services)
            {
                string path = Path.GetDirectoryName(Assembly.GetCallingAssembly().Location);
                List<Assembly> assemblies = new List<Assembly>();
                foreach (string dll in Directory.GetFiles(path, "MyNamespace*.dll"))
                {
                    assemblies.Add(Assembly.LoadFrom(dll));
                }
                services.Scan(scan => scan
                    .FromAssemblies(assemblies)
                    .AddClasses(classes => classes.Where(types => 
    types.FullName.StartsWith("MyNamespace.")))
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .AsMatchingInterface()
                    .WithTransientLifetime()
                );
            }
        }
    }
