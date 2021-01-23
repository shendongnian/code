    // Preload assets
    static readonly string[] preloadAssets =
    {
         "Textures\\texture1",
    };
        
    protected override void LoadContent()
    {
        foreach ( string asset in preloadAssets )
        {
            Content.Load<object>(asset);
        }
    }
