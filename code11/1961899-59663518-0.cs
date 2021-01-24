    public interface IGeneralSettings
    {
        Dictionary<string, GeneralSettings> SettingsDict { get; }
    }
    public class UserGeneralSettings : AppGeneralSettings<UserGeneralSettings>, IGeneralSettings
    {
        public Dictionary<string, GeneralSettings> SettingsDict { get; private set; } = new Dictionary<string, GeneralSettings>();
    }
