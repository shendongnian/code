public byte[] GetImageStreamAsBytes(Stream input)
{
  var buffer = new byte[16*1024];
  using (MemoryStream ms = new MemoryStream())
  {
    int read;
    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
    {
                ms.Write(buffer, 0, read);
    }
      return ms.ToArray();
   }
}
And you could use the plugin **FileUploaderPlugin** to upload the image to service .
    CrossFileUploader.Current.UploadFileAsync("<URL HERE>", new FileBytesItem("<REQUEST FIELD NAME HERE>","<FILE BYTES HERE>","<FILE NAME HERE>"), new Dictionary<string, string>()
                {
                   {"<HEADER KEY HERE>" , "<HEADER VALUE HERE>"}
                }
    );
For more details and usage of the plugin you could check https://github.com/CrossGeeks/FileUploaderPlugin
