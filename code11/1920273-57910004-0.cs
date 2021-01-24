private void CreateBucket(string bucketName)
{
    var storage = StorageClient.Create();
    storage.CreateBucket(s_projectId, bucketName);
    Console.WriteLine($"Created {bucketName}.");
}
If where bucketName you pass gs://your-bucket/abc
Your item will be placed in that route.
