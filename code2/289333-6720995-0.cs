         private void Media_Ended(object sender, EventArgs e)
    {
        media.Position = TimeSpan.Zero;
       media.LoadedBehavior = MediaState.Play;
    }
