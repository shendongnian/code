    public void ConfigureServices(IServiceCollection services) {
        AWSCredentials credentials = new BasicAWSCredentials(configuration["AccessKey"], configuration["AccessSecret"]);
        services.AddTransient<IAmazonDynamoDB>(sp => 
            new AmazonDynamoDBClient(credentials, RegionEndpoint.GetBySystemName(""))
        );
        //here pass the IAmazonDynamoDB to below IOC
        services.AddSingleton<IPocoDynamo>(serviceProvider => {
            var pocoDynamo = new PocoDynamo(serviceProvider.GetRequieredService<IAmazonDynamoDB>());
            pocoDynamo.SomeMethod();
            return pocoDynamo;
        });
    }
