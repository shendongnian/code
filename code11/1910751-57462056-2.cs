    using Amazon.S3;
    using Amazon;
    using Amazon.S3.Transfer;
      using (var client = new AmazonS3Client("awsAccessKeyId", 
                   "awsSecretAccessKey", RegionEndpoint.{yourregionendpoint}))
        {
          PutObjectRequest objReq = new PutObjectRequest
         {
             Key = "FolderName"+"/"+"ImageOne", //If you create folder inside 
                                      bucket then you use key                                   
                            otherwise without key also upload data successfully.
             FilePath = "E:\\blah\\imageone.jpg",
             BucketName = "your bucket name",
             CannedACL = S3CannedACL.Private,
         };
            PutObjectResponse response = s3newClient.PutObject(objReq);
            if (response.ETag != null)
               {
                string etag = response.ETag;
                string versionID = response.VersionId;
               }
            }
        }
