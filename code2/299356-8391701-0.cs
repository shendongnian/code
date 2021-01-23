        var request = new GetObjectRequest { BucketName = containerName, Key = blobName };
        GetObjectResponse response = null;
            try
            {
                response = client.GetObject(request));
            }
            catch (AmazonS3Exception ex)
            {
                if ((ex.ErrorCode == "NoSuchBucket") || (ex.ErrorCode == "AccessDenied") || (ex.ErrorCode == "InvalidBucketName") || (ex.ErrorCode == "NoSuchKey"))
                {
                    return null;
                }
                throw;
            }
            return response.ResponseStream;
