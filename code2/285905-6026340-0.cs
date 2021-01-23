    interface IOutputValueProvider
	{
		Double GetBattery();
		Double GetSignal();
		Int32 GetIntegrationTime();
		Double GetDictionaryValue(String key);
	}
	interface IAnalogOutputter
	{
		double getVoltage(IOutputValueProvider provider);
	}
	class BatteryAnalogOutputter : IAnalogOutputter
	{
		double getVoltage(IOutputValueProvider provider)
		{
			return provider.GetBattery();
		}
	}
	class DictionaryValueOutputter : IAnalogOutputter
	{
		public String DictionaryKey { get; set; }
		public double getVoltage(IOutputValueProvider provider)
		{
			return provider.GetDictionaryValue(DictionaryKey);
		}
	}
