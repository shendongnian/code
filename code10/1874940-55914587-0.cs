    var profile = new InstanceProfileAWSCredentials();
    using (var s3Client = new AmazonS3Client(profile, bucketRegion))
    {
    ListObjectsV2Request request = new ListObjectsV2Request
    {
    BucketName = bucketName,
    MaxKeys = 10
    };
    ListObjectsV2Response response;
    response = s3Client.ListObjectsV2Async(request).Result;
            // Process the response.
            foreach (S3Object entry in response.S3Objects)
            {
                keyValuePairs.Add(entry.Key, entry.Size);
            }
    }
