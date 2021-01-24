  public Texture2D texPlayerTexture;
  private Vector2 vecPlayerPostion;
  // Store the previous position
  private Vector2 vecPlayerLastPostion;
  public PlayerShip()
  // ...
  public void Update(GameTime gameTime)
  {
     // Store the value
     vecPlayerLastPostion = vecPlayerPostion;
     var delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
// ...
  public void Draw(SpriteBatch spriteBatch)
  {
     // Draw the texture halfway between the previous position and current at .4f alpha
     spriteBatch.Draw(texPlayerTexture, (vecPlayerPostion + vecPlayerLastPostion) / 2, null, new Color (1,1,1,0.4f), 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
     spriteBatch.Draw(texPlayerTexture, vecPlayerPostion, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
  }
As a side note:
It would be better to store the `KeyboardState` into a variable instead of calling `Keyboard.GetState()` multiple times.
