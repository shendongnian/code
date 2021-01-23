    GraphicsDevice.SetRenderTarget(Trails);
            
    spriteBatch.Begin();
    for (float i = 0; i <= (LightEmitter - LastEmitterPos).Length(); i++)
    {
        Vector2 Pos = Vector2.Lerp(LastEmitterPos, LightEmitter, i/(LightEmitter - LastEmitterPos).Length());
        spriteBatch.Draw(LightTrail, Pos, new Rectangle(0, 0, 32, 3), Color.White, MathHelper.ToRadians(90.0f), new Vector2(16, 1.5f), 1.0f, SpriteEffects.None, 1f);
    }
    spriteBatch.End();
    GraphicsDevice.SetRenderTarget(null);
    spriteBatch.Begin();
    spriteBatch.Draw(Trails, Vector2.Zero, Color.White);
    spriteBatch.End();
    base.Draw(gameTime);
