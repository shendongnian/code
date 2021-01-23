    public interface ISettings
    {
        Dictionary<string,object> Values{ get; set; }
        public object GetDefaultValue(string key);
        // Whatever else you might need
    }
    public class CustomAppSettings : ApplicationSettingsBase
    {
        public ISettings Settings { get; set; }
        public override object this[string propertyName]
        {
            get
            {
                return this.Settings.Values[propertyName];
            }
            set
            {
                this.Settings.Values[propertyName] = value;
            }
        }
        // There will be more implementation work for this class I'm sure
    }
