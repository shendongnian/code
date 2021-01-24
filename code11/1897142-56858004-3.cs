      public async Task<FileStreamWithLengthResult> Download()
            {
                IAmazonS3 s3Client = GetS3Client();
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectKey,
                };
                GetObjectResponse response = await s3Client.GetObjectAsync(request).ConfigureAwait(false);
                return new FileStreamWithLengthResult(response.ResponseStream, "application/octet-stream", "SomeFile.exe");
    
            }
