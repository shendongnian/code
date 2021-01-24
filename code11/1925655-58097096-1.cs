    public class PlayerController : MonoBehaviour, IUnityAdsListener
    {
        private string gameId;
        private bool testMode;
        private string placementId;
    
        private bool adsAreReady;
    
        private void Start()
        {
            gameId = "<my id here>";
            testMode = false;
            placementId = "<placement id here>";
            // WAIT FOR ADS
            Advertisment.AddListener(this);
            Advertisement.Initialize(gameId, true);
        }
    
        public void ShowAd()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                //Give internet connectivity feedback here
    
                return;
            }
    
            if(!adsAreReady)
            {
                // Give not ready yet feedback
           
                return;
            }
    
            ShowOptions options = new ShowOptions();
            Advertisement.Show(placementId, options);
        }
    
        // Implement IUnityAdsListener interface methods:
        public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) 
        {
            // Define conditional logic for each ad completion status:
            switch(showResult)
            {
                case ShowResult.Finished:
                    // Reward the user for watching the ad to completion.
                    break;
                case ShowResult.Skipped:
                    // Do not reward the user for skipping the ad.
                    break;
                case ShowResult.Failed:
                    Debug.LogWarning (“The ad did not finish due to an error.);
                    break;
            }
        }
    
        public void OnUnityAdsReady (string placementId) 
        {
            if (placementId != myPlacementId) return;
            adsAreReady = true;
        }
    
        public void OnUnityAdsDidError (string message) 
        {
            // Log the error.
        }
    
        public void OnUnityAdsDidStart (string placementId) 
        {
            // Optional actions to take when the end-users triggers an ad.
        } 
    }
