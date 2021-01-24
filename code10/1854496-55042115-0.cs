    public class AWSService : IAWSService
    {
        private readonly IAmazonS3 _s3Client;
    
        public AWSService(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }
    
        public async Task<byte[]> ReadObjectFromS3Async(string bucketName, string keyName)
        {
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
    
                    MemoryStream ms = new MemoryStream();
    
                    using (var getObjectResponse = await _s3Client.GetObjectAsync(request))
                    {
                        getObjectResponse.ResponseStream.CopyTo(ms);
                    }
                    var download = new FileContentResult(ms.ToArray(), "application/pdf");
    
                    return download.FileContents;
    
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine("Error encountered ***. Message:'{0}' when writing an object", e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown encountered on server. Message:'{0}' when writing an object", e.Message);
            }
            return null;
    
        }
    }
