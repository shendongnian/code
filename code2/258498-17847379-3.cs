    public class Document
    {
    	public int? DocumentID { get; set; }
    	public string FileName { get; set; }
    	public byte[] Data { get; set; }
    	public string ContentType { get; set; }
    	public int? ContentLength { get; set; }
    
    	public Document()
    	{
    		DocumentID = 0;
    		FileName = "New File";
    		Data = new byte[] { };
    		ContentType = "";
    		ContentLength = 0;
    	}
    }
