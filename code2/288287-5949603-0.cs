    using (var s3Client = AWSClientFactory.CreateAmazonS3Client("MyAccessKey", "MySecretKey"))
    {
        GetPreSignedUrlRequest request = new GetPreSignedUrlRequest()
            .WithBucketName("MyBucketName")
            .WithKey("MyFileKey")
            .WithProtocol(Protocol.HTTP)
            .WithExpires(DateTime.Now.AddMinutes(3));
    
        string url = s3Client.GetPreSignedURL(request);
    }
