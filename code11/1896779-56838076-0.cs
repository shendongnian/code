    public interface IApplicationProperties
    {
        object GetProperty(string key);
        void SetProperty(string key, object value);
        Task SavePropertiesAsync();
    }
