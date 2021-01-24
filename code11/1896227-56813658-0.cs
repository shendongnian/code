    byte bin = ...
    using (var stream = new MemoryStream(bin))
    {
        var request = new PutObjectRequest
        {
            BucketName = input.Bucket,
            InputStream = stream,
            ContentType = "image/jpg",
            Key = image.ImageName
        }
        var response = await S3Client.PutObjectAsync(request).ConfigureAwait(false);
    }
