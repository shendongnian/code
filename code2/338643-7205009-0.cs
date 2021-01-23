    public interface IGatewayResponseReaderMetadata
    {
    	string Key { get; }
    }
    [MetadataAttribute]
    [AttributeUsage( AttributeTargets.Class | AttributeTargets.Property )]
    public class GatewayResponseReaderExportAttribute : ExportAttribute
    {
    	public GatewayResponseReaderExportAttribute( string key )
    		: base( typeof( IGatewayResponseReader ) )
    	{
    		this.Key = key;
    	}
    
    	public string Key { get; set; }
    }
    
    [GatewayResponseReaderExport("value1")]
    public class TestReader1 : IGatewayResponseReader
    {
    }
