    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                    .AddViewLocalization(o => o.ResourcesPath = "Resources")
                    .AddDataAnnotationsLocalization(o =>
                     {
                         var type = typeof(SharedResources);
                         var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
                         var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
                         var localizer = factory.Create("SharedResources", assemblyName.Name);
                         o.DataAnnotationLocalizerProvider = (t, f) => localizer;
                     });
