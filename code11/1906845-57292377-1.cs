    _server = new TestServer(new WebHostBuilder()
                    .UseEnvironment("Testing")
                    .UseContentRoot(applicationPath)
                    .UseConfiguration(new ConfigurationBuilder()
                        .SetBasePath(applicationPath)
                        .AddJsonFile("appsettings.json")
                        .AddJsonFile("appsettings.Testing.json")
                        .Build()
                    )
                    .UseStartup<TestStartup>());
    _client = _server.CreateClient();
    // Act
    var response = await _client.GetAsync("/");
    
    // Assert
    response.EnsureSuccessStatusCode();
