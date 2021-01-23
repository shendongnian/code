    [MetadataType(typeof(FooMetadata))]
    [TableGroupName("Foo")]
    public partial class Foo { }
    
    public class FooMetadata
    {
    	[ScaffoldColumn(false)]		// hide Id column
    	public object Id { get; set; }
    	
    	[ScaffoldColumn(true)]
    	public object Name { get; set; }
    }
