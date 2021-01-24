    public static class Localization
    {
        public static event Action OnLocalizationReady;
        public static async void Initialize()
        {
            await LoadMetaData();
            OnLocalizationReady?.Invoke();
        }
        ...
    }
