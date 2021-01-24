    public static AmazonS3Client InitS3Client()
    {
        string accessKeyID = "jfjfjfj";
        string secretAccessKeyID = "jfjfjf";
        BasicAWSCredentials creds = new BasicAWSCredentials(accessKeyID, secretAccessKeyID);
        AmazonS3Config config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.USEast2
        };
    
        return new AmazonS3Client(creds, config);
    }
