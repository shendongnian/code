    [RequireComponent(typeof(Button))]
    public class UnityAds : MonoBehaviour, IUnityAdsListener
    {
        private Button rewardableAdButton;
        public const string GameId = "YourGameID";
        public const bool TestMode = true; // Change this to false when going live
        private readonly string bannerPlacementId = "YourBannerPlacementId";
        private readonly string rewardVideoPlacementId = "YourVideoPlacementId";
        void Awake()
        {
            rewardableAdButton = GameObject.FindGameObjectWithTag("RewardableAd").GetComponent<Button>();
        }
        void Start()
        {
            if (rewardableAdButton)
            {
                rewardableAdButton.onClick.AddListener(ShowRewardedVideo);
            }
            Advertisement.AddListener(this);
            if (Advertisement.isSupported && !Advertisement.isInitialized)
            {
                Advertisement.Initialize(GameId, TestMode);
            }
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            StartCoroutine(ShowBannerWhenReady());
        }
        #region ####### REWARDABLE AD ##########
        void ShowRewardedVideo()
        {
            Advertisement.Show(rewardVideoPlacementId);
        }
        public void OnUnityAdsReady(string placementId)
        {
             rewardableAdButton.interactable = Advertisement.IsReady(rewardVideoPlacementId);
        }
        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log("Ad started");
        }
        public void OnUnityAdsDidError(string message)
        {
            Debug.Log("Error while playing Ad");
        }
        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
            {
                Debug.Log("Ad is finished, reward the player");
            }
            else if (showResult == ShowResult.Skipped)
            {
                Debug.Log("User skipped, do not reward the player");
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogWarning("The ad did not finish due to an error.");
            }
        }
        #endregion
        #region ########## BANNER ##########
        public IEnumerator ShowBannerWhenReady()
        {
            while (!Advertisement.IsReady(bannerPlacementId))
            {
                yield return new WaitForSeconds(0.1f);
            }
            Advertisement.Banner.Show(bannerPlacementId);
        }
        public void HideBanner()
        {
            Advertisement.Banner.Hide(false);
        }
        #endregion
    }
