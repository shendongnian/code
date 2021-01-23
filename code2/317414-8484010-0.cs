    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        int x;
        int y;
        float z = 250f;
        Texture2D Overlay;
        Texture2D RotatingBackground;
        Rectangle? sourceRectangle;
        Color color;
        float rotation;
        Vector2 ScreenCenter;
        Vector2 Origin;
        Vector2 scale;
        Vector2 Direction;
        SpriteEffects effects;
        float layerDepth;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
            graphics.ApplyChanges();
            Direction = Vector2.Zero;
            IsMouseVisible = true;
            ScreenCenter = new Vector2(graphics.PreferredBackBufferWidth / 2, graphics.PreferredBackBufferHeight / 2);
            Mouse.SetPosition((int)graphics.PreferredBackBufferWidth / 2, (int)graphics.PreferredBackBufferHeight / 2);
            sourceRectangle = null;
            color = Color.White;
            rotation = 0.0f;
            scale = new Vector2(1.0f, 1.0f);
            effects = SpriteEffects.None;
            layerDepth = 1.0f;
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Overlay = Content.Load<Texture2D>("Overlay");
            RotatingBackground = Content.Load<Texture2D>("Background");
            Origin = new Vector2((int)RotatingBackground.Width / 2, (int)RotatingBackground.Height / 2);
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            float timePassed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState ms = Mouse.GetState();
            Vector2 MousePosition = new Vector2(ms.X, ms.Y);
            Direction = ScreenCenter - MousePosition;
            if (Direction != Vector2.Zero)
            {
                float angle = 0;
                angle = (float)Math.Atan2(Direction.Y, Direction.X) - rotation;
                Direction.X = (float)Math.Cos(angle);
                Direction.Y = (float)Math.Sin(angle);
                Direction.Normalize();
            }
            x += (int)(Direction.X * z * timePassed);
            y += (int)(Direction.Y * z * timePassed);
            //No rotation = texture scrolls as intended, With rotation = texture no longer scrolls in the direction of the mouse. My update method needs to somehow compensate for this.         
            rotation += .01f ;
            if (rotation > MathHelper.Pi * 2)
            {
                rotation -= (MathHelper.Pi * 2);
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.LinearWrap, null, null);
            spriteBatch.Draw(RotatingBackground, ScreenCenter, new Rectangle(x, y, RotatingBackground.Width, RotatingBackground.Height), color, rotation, Origin, scale, effects, layerDepth);
            spriteBatch.Draw(Overlay, Vector2.Zero, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }  
