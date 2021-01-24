    var internalCtor = typeof(RetryExponential)
        .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
        .Single();
    
    var instance = (RetryExponential)internalCtor.Invoke(
        new object[] { TimeSpan.FromSeconds(2), TimeSpan.FromMinutes(8), TimeSpan.FromMinutes(2), 3 }
        );
    
    Console.WriteLine(instance.DeltaBackoff); // 00:02:00
