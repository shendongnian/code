    public bool Upload(string filePath, Stream inputStream, double contentLength, string contentType)
    {
      try
      {
          var request = new PutObjectRequest();
          string _bucketName = "";
    
          request.BucketName = _bucketName;
          request.CannedACL = S3CannedACL.PublicRead;
          request.InputStream = inputStream;
          request.Key = filePath;
          request.Headers.ContentType = contentType;
    
          PutObjectResponse response = _amazonS3Client.PutObject(request);
    
          return true;
    
      }catch(Exception ex)
      {
          return false;
      }
    }
