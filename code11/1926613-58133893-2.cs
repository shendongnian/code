    public void ConfigureServices(IServiceCollection services) {
        AWSCredentials credentials = new BasicAWSCredentials(configuration["AccessKey"], configuration["AccessSecret"]);
        services.AddTransient<IAmazonDynamoDB>(sp => 
            new AmazonDynamoDBClient(credentials, RegionEndpoint.GetBySystemName(""))
        );
        //here pass the IAmazonDynamoDB to below IOC
        services.AddSingleton<IPocoDynamo>(serviceProvider => 
            new PocoDynamo(serviceProvider.GetRequieredService<IAmazonDynamoDB>())
        );
    }
