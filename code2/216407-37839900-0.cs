    namespace Xml2CSharp
    {
    	[XmlRoot(ElementName="entry")]
    	public class Entry {
    		[XmlElement(ElementName="hybrisEntryID")]
    		public string HybrisEntryID { get; set; }
    		[XmlElement(ElementName="mapicsLineSequenceNumber")]
    		public string MapicsLineSequenceNumber { get; set; }
