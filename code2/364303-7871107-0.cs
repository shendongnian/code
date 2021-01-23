	[DataContract(Namespace = "http://www.smarteam.com/dev/ns/iplatform/embeddedscripts")]
	[KnownType(typeof(SofDictionaryItem[]))]
	[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
	public class Execute
	{
		[DataMember(Order = 0)]
		public string ContextHandle { get; set; }
		
		[DataMember(Order = 1)]
		public string ScriptLanguage { get; set; }
		
		public string Script { get; set; }
		
		[DataMember(Name = "Script", Order = 2, EmitDefaultValue = false)]
		private CDataWrapper ScriptCData
		{
			get { return Script; }
			set { Script = value; }
		}
		
		[DataMember(Order = 3)]
		public object Params { get; set; }
	}
	
	[DataContract(Namespace = "http://www.smarteam.com/dev/ns/SOF/2.0", Name = "DictionaryItem")]
	public class SofDictionaryItem
	{
		[DataMember]
		public object Key { get; set; }
		
		[DataMember]
		public object Value { get; set; }
	}
