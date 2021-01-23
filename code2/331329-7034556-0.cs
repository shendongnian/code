    protected override void OnActivated(object sender, EventArgs args)
    {
      base.OnActivated(sender, args);
      // cache music and trial mode values
      Globals.GameHasMusicControl = MediaPlayer.GameHasControl;
    }
