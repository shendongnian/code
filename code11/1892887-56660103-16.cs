    public static class Localization
    {
        public static event Action OnLocalizationReady;
        public static bool isInitialized;
        public static async void Initialize()
        {
            await LoadMetaData();
            isInitialized = true;
            OnLocalizationReady?.Invoke();
        }
        ...
    }
