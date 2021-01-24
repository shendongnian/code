    public static MainActivity Instance;
    protected override void OnCreate(Bundle bundle)
      {
        base.OnCreate(bundle);
         ...
        Instance = this;
      }
