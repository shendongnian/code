    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null);
    spriteBatch.Draw(tempHUD, viewportRect, Color.White);
    string output = "Health:";
    string output2 = "Magic:";
    Vector2 FontOrigin = HUD.MeasureString(output) / 2;
    spriteBatch.DrawString(HUD, output, FontPos, Color.Red, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
    spriteBatch.DrawString(HUD, output2, FontPos2, Color.Blue, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);
    spriteBatch.End();
