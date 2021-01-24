    private VisibilityChecker objVisibilityChecker;
    private void Awake()
    {
        objVisibilityChecker = obj.GetComponent<VisibilityChecker>();
    }
    private void Update()
    {
        if(objVisibilityChecker.IsVisible)
        {
            // Do something
        }
        else
        {
            // Do another thing
        }
    }
