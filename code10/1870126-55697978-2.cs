    public enum ValueParseTypes {
        Enum,
        DateTime,
        Int
    }
    
    public interface IDeviceValueTypedDeviceParameter<TValue> {
        string CodeName { get; }
        TValue Value { get; set; }
        Guid DeviceId { get; set; }
        ValueParseTypes ParseType { get; set; }
    
        bool IsPossibleValue(DeviceParameter aValue);
    }
    
    public abstract class DeviceValueTypedDeviceParameter<TValue> : IDeviceValueTypedDeviceParameter<TValue> {
        public string CodeName { get; }
        public TValue Value { get; set; }
        public Guid DeviceId { get; set; }
        public ValueParseTypes ParseType { get; set; }
    
        public DeviceValueTypedDeviceParameter(string codeName, ValueParseTypes parseType) {
            this.CodeName = codeName;
            this.ParseType = parseType;
        }
    
        public virtual bool IsPossibleValue(DeviceParameter aValue) => false;
    }
    
    public class ArmingStatusParameter : DeviceValueTypedDeviceParameter<ArmingStatuses> {
        public const string CODE_NAME = "ArmingStatus";
    
        public ArmingStatusParameter() : base(CODE_NAME, ValueParseTypes.Enum) {
        }
    
        static HashSet<string> ArmingStatusesNames = Enum.GetNames(typeof(ArmingStatuses)).ToHashSet();
        public override bool IsPossibleValue(DeviceParameter aValue) => ArmingStatusesNames.Contains(aValue.Value);
    }
    
    public enum ArmingStatuses {
        Unknown,
        Armed,
        Disarmed,
    }
    
    public class PoweredOnStatusParameter : DeviceValueTypedDeviceParameter<DateTime> {
        public const string CODE_NAME = "PoweredOn";
    
        public PoweredOnStatusParameter() : base(CODE_NAME, ValueParseTypes.DateTime) {
        }
    
        public override bool IsPossibleValue(DeviceParameter aValue) => DateTime.TryParse(aValue.Value, out _);
    }
    
    public class VoltageStatusParameter : DeviceValueTypedDeviceParameter<int> {
        public const string CODE_NAME = "PoweredOn";
    
        public VoltageStatusParameter() : base(CODE_NAME, ValueParseTypes.Int) {
        }
    
        public override bool IsPossibleValue(DeviceParameter aValue) => Int32.TryParse(aValue.Value, out _);
    }
    
    
    public static class DeviceValueTypedParameterConverter {
        public static bool TryConvert<T, TValue>(DeviceParameter inputParameter, out T outputParameter)
                where T : IDeviceValueTypedDeviceParameter<TValue>, new() where TValue : struct {
            if (inputParameter == null)
                throw new NullReferenceException($"DeviceValueTypedDeviceParameter:'{typeof(T)}' must be initialized first");
    
            bool result = false;
            outputParameter = default;
            var tempOut = new T(); // create object to get around lack of abstract static methods
            if (tempOut.IsPossibleValue(inputParameter)) {
                tempOut.DeviceId = inputParameter.DeviceId;
                switch (tempOut.ParseType) {
                    case ValueParseTypes.Enum:
                        if (Enum.TryParse(inputParameter.Value, out TValue typedValue)) {
                            tempOut.Value = typedValue;
                            outputParameter = tempOut;
                            result = true;
                        }
                        break;
                    case ValueParseTypes.DateTime:
                        if (DateTime.TryParse(inputParameter.Value, out var dtValue)) {
                            tempOut.Value = (TValue)Convert.ChangeType(dtValue, typeof(TValue));
                            outputParameter = tempOut;
                            result = true;
                        }
                        break;
                    case ValueParseTypes.Int:
                        if (Int32.TryParse(inputParameter.Value, out var intValue)) {
                            tempOut.Value = (TValue)Convert.ChangeType(intValue, typeof(TValue));
                            outputParameter = tempOut;
                            result = true;
                        }
                        break;
                }
            }
    
            return result;
        }
    }
