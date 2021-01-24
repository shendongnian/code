    public class LanguageMenu : MonoBehaviour
    {
        ...
    
        // This now replaces whatever you wanted to do in Start originally
        private void OnLocalizationReady(List<string> available)
        {
            locaIsReady = true;
    
            Debug.Log(available.Count);
        }
    }
