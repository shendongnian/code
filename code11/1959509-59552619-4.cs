    // If possible already reference it via the Inspector!
    [SerializeField] private Camera mainCamera;
    // Or get and store it once 
    private void Awake ()
    {
        FetchComponents ();
    }
    // Little pro tip ;)
    // using this you can already in the Inspector click on the context menu 
    // and click on "FetchComponents"
    // this way you don't have to sear for it manually
    // and additionally you can see if it works as expected
    [ContextMenu (nameof(FetchComponents))]
    private void FetchComponents ()
    {
        if(!mainCamera) mainCamera = GetComponent<Camera>();
        if(!mainCamera) mainCamera = Camera.main;
    }
