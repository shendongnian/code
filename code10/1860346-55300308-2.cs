    public static MainActivity Instance { get; private set; }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        this.Window.RequestFeature(WindowFeatures.ActionBar);
        this.SetTheme(Resource.Style.MainTheme);
        base.OnCreate(savedInstanceState);
        MainActivity.Instance = this;
        // whatever
    }
