    [Serializable]
	public partial class Test {
		public List<Category> Category;
	}
	[Serializable]
	public partial class Category {
		[XmlElement]
		public string FileName;
		[XmlElementAttribute("Prop1")]
		[XmlElementAttribute("Prop2")]
		[XmlChoiceIdentifier("propName")]
		public string[] Properties;
		[XmlIgnore]
		public PropName[] propName;
	}
	public enum PropName {
		Prop1,
		Prop2,
	}
