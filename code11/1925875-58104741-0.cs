    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    	/// <remarks/>
    	[System.SerializableAttribute()]
    	[System.ComponentModel.DesignerCategoryAttribute("code")]
    	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    	public partial class TMMAI
    	{
    
    		private uint stringReturnField;
    
    		private string[] vectorReturnField;
    
    		/// <remarks/>
    		public uint StringReturn
    		{
    			get
    			{
    				return this.stringReturnField;
    			}
    			set
    			{
    				this.stringReturnField = value;
    			}
    		}
    
    		/// <remarks/>
    		[System.Xml.Serialization.XmlArrayItemAttribute("VectorElement", IsNullable = false)]
    		public string[] VectorReturn
    		{
    			get
    			{
    				return this.vectorReturnField;
    			}
    			set
    			{
    				this.vectorReturnField = value;
    			}
    		}
    	}
