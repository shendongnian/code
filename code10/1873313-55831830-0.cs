    AmazonS3Client S3Client = new AmazonS3Client (credentials,region);
    // Create a client
    AmazonS3Client client = new AmazonS3Client();
    
    // Create a PutObject request
    PutObjectRequest request = new PutObjectRequest
    {
        BucketName = "SampleBucket",
        Key = "Item1",
        FilePath = "contents.txt"
    };
    
    // Put object
    PutObjectResponse response = client.PutObject(request);
