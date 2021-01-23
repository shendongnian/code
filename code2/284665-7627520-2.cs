    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // overriding here
        ... draw background
    
        // *draw your text should be here
        base.Draw(gameTime);
    }
