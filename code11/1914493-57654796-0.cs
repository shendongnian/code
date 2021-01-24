    TileMedium = new TileBinding()
    {
        DisplayName = music.Name,
        Branding = TileBranding.Name,
        Content = new TileBindingContentAdaptive()
        {
            BackgroundImage = new TileBackgroundImage()
            {
                Source = uri
            },
            Children =
            {
                ......
            }
        }
    },
