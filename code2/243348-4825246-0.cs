    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
    WebResponse response = request.GetResponse();
    
    using (Stream stream = response.GetResponseStream())
    using (FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        stream.BlockCopy(fs);
    }
    
    ...
    public static class StreamHelper
    {
        public static void Copy(Stream source, Stream target, int blockSize)
        {
            int read;
            byte[] buffer = new byte[blockSize];
            while ((read = source.Read(buffer, 0, blockSize)) > 0)
            {
                target.Write(buffer, 0, read);
            }
        }
        public static void BlockCopy(this Stream source, Stream target, int blockSize = 65536)
        {
            Copy(source, target, blockSize);
        }
    }
