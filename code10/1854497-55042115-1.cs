    public class AWSService : IAWSService
    {
   
        public async Task<byte[]> ReadObjectFromS3Async(string bucketName, string keyName)
        {
            try
            {
                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = bucketName,
                    Key = keyName
                };
    
                using (var s3Client= new s3Client()/*I don't know how you create*/)
                {
                    MemoryStream ms = new MemoryStream();
    
                    using (var getObjectResponse = await s3Client.GetObjectAsync(request))
                    {
                        getObjectResponse.ResponseStream.CopyTo(ms);
                    }
                    var download = new FileContentResult(ms.ToArray(), "application/pdf");
    
                    return download.FileContents;
                }
    
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
