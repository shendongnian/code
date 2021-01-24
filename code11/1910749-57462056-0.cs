    using Amazon.S3;
    using Amazon;
    using Amazon.S3.Transfer;
    using (var client = new AmazonS3Client("awsAccessKeyId", "awsSecretAccessKey", RegionEndpoint.{yourregionendpoint}))
       {
            using (var newMemoryStream = new MemoryStream())
            {
                //Here you copy your file to the memory stream. In my case it is of IForm file. You would need to set it according to your file
                file.CopyTo(newMemoryStream);
                var uploadRequest = new TransferUtilityUploadRequest
                {
                    InputStream = newMemoryStream,
                    Key = "yourfilename",
                    BucketName = "yourbucketname",
                    CannedACL = S3CannedACL.PublicRead
                };
                var fileTransferUtility = new TransferUtility(client);
                await fileTransferUtility.UploadAsync(uploadRequest);
            }
        }
