    class Acquisition : IOutputValueProvider
	{
		public Int32 IntegrationTime { get; set; }
		public Double Battery { get; set; }
		public Double Signal { get; set; }
		public Dictionary<String, Double> DictionaryValues;
		public double GetBattery() { return Battery;}
		public double GetSignal() { return Signal; }
		public int GetIntegrationTime() { return IntegrationTime; }
		public double GetDictionaryValue(String key) 
		{
			Double d = 0.0;
			return DictionaryValues.TryGetValue(key, out d) ? d : 0.0;
		}
	}
