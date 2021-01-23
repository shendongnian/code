    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace Serialization01 {
    	[XmlRoot( "table-display-fields" )]
    	public class TableDisplayFields {
    		[XmlElement( "record-number-field" )]
    		public string RecordNumberField { get; set; }
    
    		[XmlElement( "field" )]
    		public List<string> FieldName { get; set; }
    
    		public TableDisplayFields ( ) {
    			FieldName = new List<string>( 5 );
    		}
    	}
    }
