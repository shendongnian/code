    AmazonS3Config S3Config = new AmazonS3Config {
    	ServiceURL = "s3.amazonaws.com",
    	CommunicationProtocol = Amazon.S3.Model.Protocol.HTTP
    };
    
    AmazonS3 client = Amazon.AWSClientFactory.CreateAmazonS3Client(AWS_Key, AWS_SecretKey, S3Config);
    
    PutObjectRequest UploadToS3Request = new PutObjectRequest();
    UploadToS3Request.WithFilePath(localPath)
                     .WithBucketName(bucket)
                     .WithKey(key);
    
    client.PutObject(UploadToS3Request);
