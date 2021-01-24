    public class NetworkMessage
    {
    	public Header Header {get; set;}
    	public Body Body {get; set;}
    	public Trailer Trailer {get; set;} // optional
    }
    
    public class Header
    {
    	public int Size {get; set;}
    	public string SenderId {get; set;}
    	public int MessageType {get; set;}
    }
    
    public class Body
    {
    	public byte[] Buffer {get; set;}
    }
