     public async Task<List<string>> ListS3ObjectsNames(string bucket, string prefix)
            {
                var awsAccessKey = "dasdasda";
                var awsSecretKey = "asdadasdsecret";
                var region = Amazon.RegionEndpoint.USEast1;
                using (var client = new AmazonS3Client(awsAccessKey, awsSecretKey, region))
                {
                    var response = await client.ListObjectsAsync(bucket, prefix);
                    return response.S3Objects.Count == 0 ? new List<string>() : response.S3Objects.Select(x => x.Key).ToList();
                }
            }
