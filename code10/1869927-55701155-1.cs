       protected override void OnDetachedFromWindow()
        {
            base.OnDetachedFromWindow();
            _player.Stop();
            _player.Release();
        }
