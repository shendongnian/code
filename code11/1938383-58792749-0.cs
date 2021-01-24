byte[] byteArray = Encoding.UTF8.GetBytes(file.Filebase64);
stream= new MemoryStream(byteArray);
var request = new PutObjectRequest
{
  
  Key=file.File_name,
  BucketName = bucket_name,
  InputStream = stream,
  ContentType = "text/plain",
  CannedACL = S3CannedACL.PublicRead
};
where Image file model class look like this :
public class ImageModel
{
        public String File_name { set; get; }
        public String Filebase64 { set; get; }
}
