    using (var inputStream = new MemoryStream(Convert.FromBase64String(illustrationDocumentBody)))
    {
        await s3Client.PutObjectAsync(new PutObjectRequest
        {
            InputStream = inputStream,
            ContentType = "application/pdf",
            BucketName = Environment.GetEnvironmentVariable("ESIS_SYNC_BUCKET"),
            Key = $"Opportunities/{oppName}/ESIS-{brokerName}-{productCode}-{customerName}.pdf",
            CannedACL = S3CannedACL.BucketOwnerFullControl
        });
    }
