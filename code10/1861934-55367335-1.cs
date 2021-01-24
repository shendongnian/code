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
---
A third solution would be to unrestrict the frame rate:
In the constructor for game1:
// ...
 public Game1()
 {
    graphics = new GraphicsDeviceManager(this);
    graphics.PreferredBackBufferWidth = 1920;  // set this value to the desired width of your window
    graphics.PreferredBackBufferHeight = 1080;   // set this value to the desired height of your window
    graphics.IsFullScreen = true;
    graphics.ApplyChanges();
    // Remove 60 fps target
    IsFixedTimeStep = false;
    // don't wait on vsync(will limit to 60 fps)
    graphics.SynchronizeWithVerticalRetrace = false;
    Content.RootDirectory = "Content";
        }
