    [XmlRoot(ElementName = "SensorDefinition")]
	public class SensorDefinition
	{
		[XmlElement(ElementName = "StartingWavelength")]
		public int StartingWavelength { get; set; }
		[XmlElement(ElementName = "StoppingWavelength")]
		public int StoppingWavelength { get; set; }
		[XmlElement(ElementName = "TargetWavelength")]
		public int TargetWavelength { get; set; }
	}
	[XmlRoot(ElementName = "SensorDefinitionCollection")]
	public class SensorDefinitionCollection
	{
		[XmlElement(ElementName = "SensorDefinition")]
		public List<SensorDefinition> SensorDefinition { get; set; }
	}
	[XmlRoot(ElementName = "SensorConfig")]
	public class SensorConfig
	{
		[XmlElement(ElementName = "SampleCount")]
		public int SampleCount { get; set; }
		[XmlElement(ElementName = "SampleDelay")]
		public int SampleDelay { get; set; }
		[XmlElement(ElementName = "SampleTolerance")]
		public int SampleTolerance { get; set; }
	}
	[XmlRoot(ElementName = "SensorRunner")]
	public class SensorRunner
	{
		[XmlElement(ElementName = "SensorConfig")]
		public List<SensorConfig> SensorConfig { get; set; }
	}
	[XmlRoot(ElementName = "Session")]
	public class SensorSession
	{
		[XmlElement(ElementName = "SensorDefinitionCollection")]
		public List<SensorDefinitionCollection> SensorDefinitionCollection { get; set; }
		[XmlElement(ElementName = "SensorRunner")]
		public List<SensorRunner> SensorRunner { get; set; }
	}
