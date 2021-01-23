    Texture2D canvas;
    Rectangle tracedSize;
    UInt32[] pixels;
    protected override void Initialize()
    {
        tracedSize = GraphicsDevice.PresentationParameters.Bounds;
        canvas = new Texture2D(GraphicsDevice, tracedSize.Width, tracedSize.Height, false, SurfaceFormat.Color);
        pixels = new UInt32[tracedSize.Width * tracedSize.Height];
        base.Initialize();
    }
    Random rnd = new Random();
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        GraphicsDevice.Textures[0] = null;
        pixels[rnd.Next(pixels.Length)] = 0xFF00FF00;
        canvas.SetData<UInt32>(pixels, 0, tracedSize.Width * tracedSize.Height);
        spriteBatch.Begin();
        spriteBatch.Draw(canvas, new Rectangle(0, 0, tracedSize.Width, tracedSize.Height), Color.White);
        spriteBatch.End();
        base.Draw(gameTime);
    }
