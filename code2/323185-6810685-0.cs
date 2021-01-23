    protected override void Update(GameTime gameTime)
    {
        TimeSpan elapsed = gameTime.ElapsedGameTime;
        TimeSpan total = gameTime.TotalGameTime;
        // Personally, I just do this:
        float seconds = (float)gameTime.ElapsedGameTime.TotalSeconds;
        // ...
    }
