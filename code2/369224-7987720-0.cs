    interface IXmlConvertable{
		XElement ToXml();
}
	public class MyClass : IXmlConvertable{
		public string Name { get; set; }
		public string ID { get; set; }
		public XElement ToXml(){
			var retval = new XElement("MyClass"
				, new XAttribute("Name", new XCData(Name))
				, new XAttribute("ID", new XCData(ID))
				);
			return retval;
		}
	}
