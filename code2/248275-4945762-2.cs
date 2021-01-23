	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = false)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public partial class graph
	{
		private string myStringField;
		private int myIntField;
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
		public string myString
		{
			get { return this.myStringField; }
			set { this.myStringField = value; }
		}
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified)]
		public int myInt
		{
			get { return this.myIntField; }
			set { this.myIntField = value; }
		}
	
	}
