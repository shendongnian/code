    using (var scopedServiceProvider = sp.CreateScope())
    {
        scopedServiceProvider.GetService<IPersonProvider>(); // valid
        sp.GetService<IPersonProvider>(); // not valid
    }
