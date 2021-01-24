    private void Awake()
    {
        if(Localization.isInitialized)
        {
            OnLocaInitialized();
        }
        else
        {
            Localization.OnInitialized -= OnLocaInitialized;
            Localization.OnInitialized += OnLocaInitialized;
        }
    }
    private void OnDestroy ()
    {
        Localization.OnInitialized -= OnLocaInitialized;
    }
    private void OnLocaInitialized()
    {
        var available = Localization.Available;
        ...
    }
    private void Update()
    {
        if(!Localization.isInitialized) return;
        ...
    }
