    public class CircuitLib
    {
        public CircuitSetting Setting { get; }
        public CircuitEnvironment Environment { get; }
        public CircuitOutput Command { get; }
    }
    //Obviously you need one for each type above
    public class CircuitSetting
    {
        CircutSettingCommand1 Command1 { get; }
        CircutSettingCommand30 Command30 { get; }
    }
    public class CircutSettingCommand1 
    {
        Send(string command);
    }
