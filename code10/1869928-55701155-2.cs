    class ExoPlayerInstance
    {
        private static SimpleExoPlayer _player;
        public static SimpleExoPlayer player
        {
            get
            {
                if (_player == null)
                {
                    _player = ExoPlayerFactory.NewSimpleInstance(Application.Context, new DefaultTrackSelector());
                    _player.PlayWhenReady = true;
                }
                return _player;
            }
        }
    }
