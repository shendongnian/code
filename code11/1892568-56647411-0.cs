    [TestMethod]
    public async Task DeviceToCloudMessageHostedService_Should_DoStuff() {
        //Arrange
        IServiceCollection services = new ServiceCollection();
        services.AddSingleton<IHostedService, DeviceToCloudMessageHostedService>();
        //mock the dependencies for injection
        services.AddSingleton(Mock.Of<IDeviceToCloudMessageService>(_ =>
            _.DoStuff(It.IsAny<CancellationToken>()) == Task.CompletedTask
        ));
        services.AddSingleton(Mock.Of<IOptionsMonitor<AppConfig>>(_ =>
            _.CurrentValue == Mock.Of<AppConfig>(c => 
                c.Parameter1 == TimeSpan.FromMilliseconds(1000)
            )
        ));
        var serviceProvider = services.BuildServiceProvider();
        var hostedService = serviceProvider.GetService<IHostedService>();
        //Act
        await hostedService.StartAsync(CancellationToken.None);
        await Task.Delay(1000);//Give some time to invoke the methods under test
        await hostedService.StopAsync(CancellationToken.None);
        //Assert
        var deviceToCloudMessageService = serviceProvider
            .GetRequiredService<IDeviceToCloudMessageService>();
        //extracting mock to do verifications
        var mock = Mock.Get(deviceToCloudMessageService);
        //assert expected behavior
        mock.Verify(_ => _.DoStuff(It.IsAny<CancellationToken>()), Times.AtLeastOnce);
        mock.Verify(_ => _.EndStuff(), Times.AtLeastOnce());
    }
