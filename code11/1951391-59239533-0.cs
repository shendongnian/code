        builder.Register(context => {
            var credentials = new BasicAWSCredentials("accessKeyId1", "SecretAccessKey1");
            var config = new AmazonS3Config {
                RegionEndpoint = RegionEndpoint.GetBySystemName("regionEndpoint")
            };
            return new AmazonS3Client(credentials, config);
        }).Named<IAmazonS3>("client1").SingleInstance();
        builder.Register(context => {
            var credentials = new BasicAWSCredentials("accessKeyId2", "SecretAccessKey2");
            var config = new AmazonS3Config {
                RegionEndpoint = RegionEndpoint.GetBySystemName("regionEndpoint")
            };
            return new AmazonS3Client(credentials, config);
        }).Named<IAmazonS3>("client2").SingleInstance();
