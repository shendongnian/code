	SpriteBatch spriteBatch;
	Texture2D whiteRectangle;
	protected override void LoadContent()
	{
		base.LoadContent();
		spriteBatch = new SpriteBatch(GraphicsDevice);
		// Create a 1px square rectangle texture that will be scaled to the
		// desired size and tinted the desired color at draw time
		whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
		whiteRectangle.SetData(new[] { Color.White });
	}
	protected override void UnloadContent()
	{
		base.UnloadContent();
		// If you are creating your texture (instead of loading it with
		// Content.Load) then you must Dispose of it
		whiteRectangle.Dispose();
	}
	protected override void Draw(GameTime gameTime)
	{
		base.Draw(gameTime);
		GraphicsDevice.Clear(Color.White);
		spriteBatch.Begin();
		// Option One (if you have integer size and coordinates)
		spriteBatch.Draw(whiteRectangle, new Rectangle(10, 20, 80, 30),
				Color.Chocolate);
		// Option Two (if you have floating-point coordinates)
		spriteBatch.Draw(whiteRectangle, new Vector2(10f, 20f), null,
				Color.Chocolate, 0f, Vector2.Zero, new Vector2(80f, 30f),
				SpriteEffects.None, 0f);
		spriteBatch.End();
	}
