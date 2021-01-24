    public static class Localization
    {
        public static async void Initialize(Action<List<string>> onSuccess)
        {
            await LoadMetaData();
    
            onSuccess?.Invoke();
        }
    
        ...
    }
