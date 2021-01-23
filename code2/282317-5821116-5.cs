    public class ServiceFile : VirtualFile
    {
        public ServiceFile(string virtualPath) : base(virtualPath)
        {
            
        }
        public string GetName(string virtualPath)
        {
            string filename = virtualPath.Substring(virtualPath.LastIndexOf("/") + 1);
            filename = filename.Substring(0, filename.LastIndexOf("."));
            return filename;
        }
        public override Stream Open()
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("<%@ ServiceHost Language=\"C#\" Debug=\"true\" Service=\"" + GetName(VirtualPath) +
                         "\" Factory=\"Core.MEFServiceHostFactory, Core\" %>");
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
