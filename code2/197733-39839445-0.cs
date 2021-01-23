                    PurObjectRequest request = new PutObjectRequest()
                    {
                        BucketName = _bucketName,
                        CannedACL = S3CannedACL.PublicRead,
                        Key =  string.Format("folderyouwanttoplacethefile/{0}", file.FileName),
                        InputStream = file.InputStream
                    };
                    YourS3client.PutObject(request);
