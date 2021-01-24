    public class StringMessage:IMessage<string>
    {
    	public string content { get; }
        public string sender { get; }
        public DateTime sent { get; }
    }
    public class FileMessage:IMessage<FileInfo>
    {
    	public FileInfo content { get; }
        public string sender { get; }
        public DateTime sent { get; }
    }
    
    public class ImageMessage:IMessage<Image>
    {
    	public Image content { get; }
        public string sender { get; }
        public DateTime sent { get; }
    }
