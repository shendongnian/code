    public class AmazonS3Service : IAmazonS3Service 
    {
         private AmazonS3 client;
         private string accessKeyID;
         private string secretAccessKeyID;
         private AmazonS3Config config;
         public AmazonS3Service()
         {
             accessKeyID = ConfigurationManager.AppSettings["AWSAccessKey"];
             secretAccessKeyID = ConfigurationManager.AppSettings["AWSSecretKey"];
             config = new AmazonS3Config();
             config.ServiceURL = ConfigurationManager.AppSettings["AWSEUEndPoint"];
          }
        public void CreateBucket(string bucketName)
        {
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID, config))
            {
                try
                {
                    PutBucketRequest request = new PutBucketRequest();
                    request.WithBucketName(bucketName)
                           .WithBucketRegion(S3Region.EU);
                     client.PutBucket(request);
                 }
                 catch (AmazonS3Exception amazonS3Exception)
                 {
                    if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                    {
                    //log exception - ("Please check the provided AWS Credentials.");
                    }
                    else
                    {
                    //log exception - ("An Error, number {0}, occurred when creating a bucket with the message '{1}", amazonS3Exception.ErrorCode, amazonS3Exception.Message);    
                    }
                }
            }
        }
         public void UploadFile(string bucketName, Stream uploadFileStream, string remoteFileName)
        {
            using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKeyID, secretAccessKeyID, config))
            {
                try
                {
                    PutObjectRequest request = new PutObjectRequest();
                    request.WithBucketName(bucketName)
                        .WithCannedACL(S3CannedACL.PublicRead)
                        .WithKey(remoteFileName)
                        .WithInputStream(uploadFileStream);
                     using (S3Response response = client.PutObject(request))
                     {
                        WebHeaderCollection headers = response.Headers;
                        foreach (string key in headers.Keys)
                        {
                            //log headers ("Response Header: {0}, Value: {1}", key, headers.Get(key));
                        }
                    }
                }
                catch (AmazonS3Exception amazonS3Exception)
                {
                    if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                    {
                    //log exception - ("Please check the provided AWS Credentials.");
                    }
                    else
                    {
                    //log exception -("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message);
                    }
                }
            }
        }
     }
