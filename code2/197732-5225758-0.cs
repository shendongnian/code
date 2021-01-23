    HttpPostedFileBase file = Request.Files[0];
       if (file.ContentLength > 0) // accept the file
            {
                string accessKey = "XXXXXXXXXXX";
                string secretKey = "122334XXXXXXXXXX";
                AmazonS3 client;
                using (client = Amazon.AWSClientFactory.CreateAmazonS3Client(accessKey, secretKey))
                {
                    MemoryStream ms = new MemoryStream();
                    PutObjectRequest request = new PutObjectRequest();
          request.WithBucketName("mybucket")
         .WithCannedACL(S3CannedACL.PublicRead)
         .WithKey("testfolder/test.jpg").InputStream = file.InputStream;
           S3Response response = client.PutObject(request);
                }
