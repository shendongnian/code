        private void CreateRegionalBucket(string location, string bucketName)
        {
            var storage = StorageClient.Create();
            Bucket bucket = new Bucket { Location = location, Name = bucketName };
            storage.CreateBucket(s_projectId, bucket);
            Console.WriteLine($"Created {bucketName}.");
        }
