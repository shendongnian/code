    private void Awake()
    {
        Localization.Initialize(OnLocalizationReady);
    }
    private void OnLocalizationReady(List<string>> available)
    {
        locaIsReady = true;
        Debug.Log(available.Count);
    }
