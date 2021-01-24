	public static class Constants
	{
		public const string DataContractNamespace = ""; // Or whatever
	}
	[DataContract(Name = "Dispatcher", Namespace = Constants.DataContractNamespace)]
	public partial class Dispatcher
	{
		[DataMember]
		private Dictionary<int, Dictionary<int, Dictionary<int, Message>>> m_DataBase;
		private Dispatcher()
		{
			m_DataBase = new Dictionary<int, Dictionary<int, Dictionary<int, Message>>>();
		}
		
		[System.Runtime.Serialization.OnDeserialized]
		void OnDeserializedMethod(System.Runtime.Serialization.StreamingContext context)
		{
			// Ensure m_DataBase is not null after deserialization (DataContractSerializer does not call the constructor).
			if (m_DataBase == null)
				m_DataBase = new Dictionary<int, Dictionary<int, Dictionary<int, Message>>>();
		}
		internal const string FileName = @"DispatcherDataBase.xml";
		
		public static Dispatcher LoadFromFile()
		{
			Dispatcher loadedDataBase;
			try
			{
				using (var stream = new FileStream(FileName, FileMode.Open))
				{
					var serializer = new DataContractSerializer(typeof(Dispatcher));
					loadedDataBase = serializer.ReadObject(stream) as Dispatcher;
				}
			}
			catch (Exception)
			{
				loadedDataBase = new Dispatcher();
			}
			return loadedDataBase;
		}
		public void SaveToFile()
		{
			using (var stream = new FileStream(FileName, FileMode.Create))
			using (var writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true })) // Optional indentation for readability only.
			{
				var serializer = new DataContractSerializer(this.GetType());
				serializer.WriteObject(writer, this);
			}
		}
	}
	// Not shown in question, added as an example
	[DataContract(Name = "Message", Namespace = Constants.DataContractNamespace)]
	public class Message
	{
		[DataMember]
		public string Value { get; set; }
	}
