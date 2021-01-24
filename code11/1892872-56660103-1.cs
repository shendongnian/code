    public class LanguageMenu : MonoBehaviour
    {
        private bool locaIsReady;
    
        private async void Awake()
        {
            Localization.OnLocalizationReady -= OnLocalizationReady;
            Localization.OnLocalizationReady += OnLocalizationReady;
    
            Localization.Initialize();
        }
    
        private void OnDestroy ()
        {
            Localization.OnLocalizationReady -= OnLocalizationReady;
        }
    
        // This now replaces whatever you wanted to do in Start originally
        private void OnLocalizationReady ()
        {
            locaIsReady = true;
            Debug.Log(Localization.Available.Count);
        }
    
        private void Update()
        {
            // Block execution until locaIsReady
            if(!locaIsReady) return;
    
            ...
        }
    }
