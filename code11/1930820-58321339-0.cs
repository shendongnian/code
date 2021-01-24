    public Fixture() {
        Car myCarObject = //... omitted for brevity
        var myCarMockService = new Mock<ICarService>();
        myCarMockService
            .Setup(x => x.GetAsync(It.IsAny<int>()))
            .ReturnsAsync(myCarObject);
            
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>()
            .ConfigureServices(services => {
                services.AddScoped<ICarService>(_ => myCarMockService.Object); // <-- NOTE
            })
        );
        Client = _server.CreateClient();
    }
    
