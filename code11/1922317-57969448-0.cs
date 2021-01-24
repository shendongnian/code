    var services = new ServiceCollection();
    services.AddSingleton<I1, C>();
    services.AddSingleton<I2>(p => (I2)p.GetService<I1>());  //Must be exactly the same lifetime scope
    var provider = services.BuildServiceProvider();
    var i1 = provider.GetRequiredService<I1>();
    var i2 = provider.GetRequiredService<I2>();
    Console.WriteLine(i1 == i2);  //True
