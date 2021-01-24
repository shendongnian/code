    public class ThermostatConfigurationItem
    {
        public TemperatureSettingKind TempSetting { get; set; }
        public HistorySettingKind HistSetting { get; set; }
        public RelayOutputs RelayOutputMask { get; set; }
        public SensorFailures SensorFailureOutputMask { get; set; }
    }
    
    public TemperatureSettingKind : sbyte
    {
        None = 0,
        Centigrade,
        Fahrenheit
    }
    
    // and so on ..
