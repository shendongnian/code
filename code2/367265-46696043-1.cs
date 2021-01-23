    // upload & add outputfolder to metadata
    
    var S3Client = new AmazonS3Client();
    
    var Request = new PutObjectRequest {
                      BucketName = bucketname,Key = S3Name,FilePath = Filepath };
    
    Request.Metadata.Add("outputfolder",@"C:\test");
    
    PutObjectResponse Response = S3Client.PutObject(Request);
    
    // download and retrieve metadata
    
    var S3Client = new AmazonS3Client();
    
    var Request = new GetObjectRequest { BucketName = bucketname,Key = S3Name };
    
    GetObjectResponse Response = S3Client.GetObject(Request);
    
    // this works
    
    string outputFolder = Response.Metadata["x-amz-meta-outputfolder"];
    
    // so does this - no need for the x-amz-meta- prefix
    
    string outputFolder = Response.Metadata["outputfolder"];
