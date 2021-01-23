    Texture2D texture;
    protected override void LoadContent()
            {
    ...
             texture = Content.Load<Texture2D>("Tank");
    ...
            }
    protected override void Draw(GameTime gameTime)
            {
    ...
             Rectangle destinationRectangle = new Rectangle(100, 100, 30, 10);
             spriteBatch.Draw(texture, destinationRectangle, Color.White);
    ...
             spriteBatch.End();
             base.Draw(gameTime);
            }
