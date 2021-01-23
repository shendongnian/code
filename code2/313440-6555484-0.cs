    public class UserControlData
    {
        public string Type { get; set; } // or assembly qualified type
        public List<ControlValue> ControlValues { get; set; }
    }
    public class ControlValue
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
    public interface IControlPersistence
    {
        List<ControlValue> GetControlValues();
        void SetControlValues(List<ControlValue> controlValues);
    }
