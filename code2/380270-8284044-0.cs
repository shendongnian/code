    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        playerTexture = Content.Load<Texture2D>(@"Textures\player");
        me = new Player(playerTexture, new Vector2(200, 200));
        me.Color = Color.White;
    }
