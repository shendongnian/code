    public static readonly DependencyProperty MusicCollectionProperty =
        DependencyProperty.Register(
            nameof(MusicCollection), typeof(Playlist),
            typeof(HeaderedPlaylistControl), null
        );
    public Playlist MusicCollection
    {
        get { return (bool)GetValue(MusicCollectionProperty); }
        set { SetValue(MusicCollectionProperty, value); }
    }
