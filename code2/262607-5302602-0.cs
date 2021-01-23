    public Draw(...)
    {
        spriteBatch.Begin();
        spriteBatch.Draw(texture1, ..., Matrix.Transform(Position), ...);
        spriteBatch.Draw(shadow, , ..., Matrix.Transform(Position + ShadowPosition), ...);
        spriteBatch.End();
    }
