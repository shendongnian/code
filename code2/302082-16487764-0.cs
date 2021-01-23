    var config = new Amazon.S3.AmazonS3Config
                    {
                        ServiceURL = "eucalyptus.test.local:8773",
                        CommunicationProtocol = Protocol.HTTP
                    };
    
                var client = new Amazon.S3.AmazonS3Client("XXXXXXXXXXXXXXXXXXKEY", "XXXXXXXXXXXXXXXXXXXXXXXXXXXXSECRET", config);
                var response = client.GetPreSignedURL(
                    new GetPreSignedUrlRequest().WithBucketName("services/Walrus/BucketName")
                                                .WithExpires(DateTime.UtcNow.AddHours(10))
                                                .WithProtocol(Protocol.HTTP)
                                                .WithVerb(HttpVerb.PUT)
                                                .WithKey("video.mp4"));
