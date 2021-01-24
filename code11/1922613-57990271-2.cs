    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
    IConfigurationRoot configuration = configurationBuilder.Add<WritableJsonConfigurationSource>(
        (Action<WritableJsonConfigurationSource>)(s =>
                                                         {
                                                             s.FileProvider = null;
                                                             s.Path = "TestSettings.json";
                                                             s.Optional = false;
                                                             s.ReloadOnChange = true;
                                                             s.ResolveFileProvider();
                                                         })).Build();
    Console.WriteLine(configuration.GetSection("setting1").Value); // Output: value1
    Console.ReadKey();
    configuration.GetSection("setting1").Value = "changed from codeeee";
    Console.WriteLine(configuration.GetSection("setting1").Value); // Output: changed from codeeee
    Console.ReadKey();
