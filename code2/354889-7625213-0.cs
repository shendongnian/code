    public override void Draw(GameTime gameTime)
    {
        GameRef.SpriteBatch.Begin(
            SpriteSortMode.Deferred,
            BlendState.AlphaBlend,
            SamplerState.PointClamp,
            null,
            null,
            null,
            player.Camera.Transformation);
        map.Draw(GameRef.SpriteBatch, player.Camera);
        sprite.Draw(gameTime, GameRef.SpriteBatch, player.Camera);
       
        base.Draw(gameTime);
        GameRef.SpriteBatch.End();
        GameRef.SpriteBatch.Begin();
        hud.Draw(gameTime);
        GameRef.SpriteBatch.End();
    }
