    interface IPrintable
    {
    	DocBody Body { get; set; }
    	public class DocBody
    	{
    		public string Text { get; set; }
    		public float FontSize { get; set; }
    	}
    }
    
    class WordDoc : IPrintable
    {
    	public IPrintable.DocBody WordBody { get; set; }
    	IPrintable.DocBody IPrintable.Body {
    		get { return WordBody; }
    		set { WordBody = value; }
    	}
    }
