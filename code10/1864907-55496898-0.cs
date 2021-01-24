	[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
	[System.SerializableAttribute()]
	[System.Diagnostics.DebuggerStepThroughAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.lol.com/Standards/lol/1")]
	[System.Xml.Serialization.XmlRootAttribute("FatherProvision", Namespace = "http://www.lol.com/Standards/lol/1", IsNullable = false)]
	public partial class FatherElement
	{
		private string FatherClassField;
		private object[] itemsField;
		private ItemsChoiceType3[] itemsElementNameField;
		private string FatherBasisField;
		private string FatherRoleField;
		private FatherProvision_ExtensionType extensionField;
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
		public string FatherClass
		{
			get
			{
				return this.FatherClassField;
			}
			set
			{
				this.FatherClassField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("FatherAuthorityLocation", typeof(FatherAuthorityLocationType))]
		[System.Xml.Serialization.XmlElementAttribute("FatherType", typeof(string), DataType = "NMTOKEN")]
		[System.Xml.Serialization.XmlElementAttribute("FatherTypeDescription", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
		public object[] Items
		{
			get
			{
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemsChoiceType3[] ItemsElementName
		{
			get
			{
				return this.itemsElementNameField;
			}
			set
			{
				this.itemsElementNameField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
		public string FatherBasis
		{
			get
			{
				return this.FatherBasisField;
			}
			set
			{
				this.FatherBasisField = value;
			}
		}
		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "NMTOKEN")]
		public string FatherRole
		{
			get
			{
				return this.FatherRoleField;
			}
			set
			{
				this.FatherRoleField = value;
			}
		}
		/// <remarks/>
		public FatherProvision_ExtensionType Extension
		{
			get
			{
				return this.extensionField;
			}
			set
			{
				this.extensionField = value;
			}
		}
	}
    public enum ItemsChoiceType3
    {
    
    	/// <remarks/>
    	FatherAuthorityLocation,
    
    	/// <remarks/>
    	FatherType,
    
    	/// <remarks/>
    	FatherTypeDescription,
    }
