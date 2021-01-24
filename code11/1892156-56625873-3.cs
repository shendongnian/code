    private void Awake()
    {
        // This makes sure the callback is added only once
        Game.OnInitialized -= OnGameInitialized;
        Game.OnInitialized += OnGameInitialized;
    }
    private void OnDestroy()
    {
        // always make sure to remove callbacks if no longer needed
        Game.OnInitialized -= OnGameInitialized;
    }
    privtae void OnGameInitialized()
    {
        offset = transform.position - Game.currentPlayer.transform.position;
    }
