     var putObjectRequest = new Amazon.S3.Model.PutObjectRequest
                            {
                                BucketName = bucketName,
                                Key = key,
                                CannedACL = S3CannedACL.PublicReadWrite
                            }; 
