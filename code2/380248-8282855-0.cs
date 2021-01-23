    protected override void Draw(GameTime gameTime) // <- do it here, not somewhere else!
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
    
        spriteBatch.Begin(); // <-- before you start to draw
    
        spriteBatch.DrawString(Font1, output, FontPos, Color.LightGreen,
            0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
    
        spriteBatch.End(); // <-- after you draw
        base.Draw(gameTime);
    }
