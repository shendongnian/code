    var assemblies = new string[] { "APP.Plugins.Test" };
            services
               .AddMvc()
               .ConfigureApplicationPartManager(apm =>
               {
                   foreach (var assemblyFile in assemblies)
                   {
                       //main assembly
                       var assembly = Assembly.Load(assemblyFile);
                       apm.ApplicationParts.Add(new AssemblyPart(assembly));
                       //view assembly
                       var assemblyView = Assembly.Load(assemblyFile+".Views");
                       apm.ApplicationParts.Add(new CompiledRazorAssemblyPart(assemblyView));                     
                   }
               });
