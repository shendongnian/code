    // Set Canned ACL (PublicRead) for an existing item
    client.PutACL(new PutACLRequest
    {
        BucketName = _awsS3AssetsBucket,
        Key = key,
        CannedACL = S3CannedACL.PublicRead
    });
