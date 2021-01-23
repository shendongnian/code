    using (var s3Client = new AmazonS3Client(Amazon.RegionEndpoint.USEast1))
    {
        GetPreSignedUrlRequest request1 = new GetPreSignedUrlRequest
        {
            BucketName = "MyBucket",
            Key = "MyKey",
            Expires = DateTime.Now.AddMinutes(5)
        };
        string urlString = s3Client.GetPreSignedURL(request1);
    }
