    [XmlRoot("Level")]
    public class LData
    {
    	[XmlElement("Warp_Blocks")]
    	public List<WarpBlock> WarpBlocks;
    }
    public class LBlock
    {
    	[XmlAttribute("row")]
    	public int row;
    	[XmlAttribute("col")]
    	public int col;
    }
    public class WarpBlock
    {
    	[XmlArray("Warp_Block")]
    	[XmlArrayItem("Block", typeof(LBlock), IsNullable = false)]
    	public List<LBlock> WarpBlocks;
    
    	public WarpBlock()
    	{
    		WarpBlocks = new List<LBlock>();
    	}
    }
    public class Program
    {
    	public static void Main()
    	{
    		string test =
    			"<?xml version=\"1.0\" ?>" +
    			"<Level>" +
    			"  <Warp_Blocks>" +
    			"        <Warp_Block>" +
    			"            <Block row=\"7\" col=\"7\" />" +
    			"            <Block row=\"2\" col=\"7\" />" +
    			"        </Warp_Block>" +
    			"        <Warp_Block>" +
    			"            <Block row=\"4\" col=\"4\" />" +
    			"            <Block row=\"3\" col=\"7\" />" +
    			"        </Warp_Block>" +
    			"  </Warp_Blocks>" +
    			"</Level>";
    
    		byte[] byteArray = Encoding.ASCII.GetBytes(test);
    		MemoryStream stream = new MemoryStream(byteArray);
    
    		XmlSerializer s = new XmlSerializer(typeof (LData));
    		LData data = (LData) s.Deserialize(stream);
    
    		foreach (var a in data.WarpBlocks)
    			foreach (var b in a.WarpBlocks)
    				Console.WriteLine(b.row + ", " + b.col);
    
    		Console.ReadKey();
    	}
    }
