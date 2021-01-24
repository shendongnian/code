    public TestFixture()
    {
         IHost host = new HostBuilder()
             .ConfigureDefaultTestHost<TestFixture>(b =>
             {
                  b.AddAzureStorage();
             })
             .Build();
             var provider = host.Services.GetService<StorageAccountProvider>();
             StorageAccount = provider.GetHost().SdkObject;
    }
