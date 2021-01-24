	[XmlRoot(ElementName = "export")]
	public partial class SchematicExport
	{
		public const string version = "D";
		[XmlAttribute("version")]
        [System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
		public string Version { get { return version; } set { /* Do nothing */ } }
		
		[XmlElement(Order = 1)]
		public Design design { get; set; }
		[XmlArray(Order = 2)]
		[XmlArrayItem(typeof(Component), ElementName = "comp")]
		public List<Component> components;
		[XmlArray(Order = 3)]
		[XmlArrayItem(typeof(LibPart), ElementName = "libpart")]
		public List<LibPart> libparts;
		[XmlArray(Order = 4)]
		[XmlArrayItem(typeof(Library), ElementName = "library")]
		public List<Library> libraries;
		[XmlArray(Order = 5)]
		[XmlArrayItem(typeof(Net), ElementName = "net")]
		public List<Net> nets;
	}
