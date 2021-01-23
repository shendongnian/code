    [MetadataType(typeof(FooMetadata))]
    [TableGroupName("Foo")]
        public partial class Foo 
    { 
    		[ScaffoldColumn(true)]
            public string MyNewColumnNotinDBTable
            {
                get
                {
    				return "FooBar";
    			}
    		}
    }
    
   
     public class FooMetadata
        {
        	[ScaffoldColumn(false)]		// hide Id column
        	public object Id { get; set; }
        	
    
        	public object Name { get; set; }
    
            public object MyNewColumnNotinDBTable { get; set; }
        }
