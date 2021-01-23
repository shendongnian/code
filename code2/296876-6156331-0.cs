    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    namespace WindowsGame1
    {
      /// <summary>
      /// This is the main type for your game
      /// </summary>
      public class Game1 : Microsoft.Xna.Framework.Game
      {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private Texture2D _texture;
    
        private MyImage _image1;
        private MyImage _image2;
        // Attributes of the composed sprite
        private float _angle = 0.0f;
        private Vector2 _position = new Vector2(100, 100);
        private Vector2 _rotationPoint = new Vector2(96, 48);
        public Game1()
        {
          graphics = new GraphicsDeviceManager(this);
          Content.RootDirectory = "Content";
        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
          // TODO: Add your initialization logic here
          base.Initialize();
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
          // Create a new SpriteBatch, which can be used to draw textures.
          spriteBatch = new SpriteBatch(GraphicsDevice);
          _texture = Content.Load<Texture2D>("Gravitar");
          // Create the two MyImage instances
          _image1 = new MyImage(_texture, Vector2.Zero, Vector2.Zero);
          _image2 = new MyImage(_texture, new Vector2(64, 0), new Vector2(64, 0));
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
          // TODO: Unload any non ContentManager content here
        }
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
          // Allows the game to exit
          if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            this.Exit();
          float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
      
          _angle += 0.5f * elapsedTime;
          if (Mouse.GetState().LeftButton == ButtonState.Pressed)
          {
            _angle = 0.0f;
          }
          if (Keyboard.GetState().IsKeyDown(Keys.Left)) 
            _position += new Vector2(-10, 0)*elapsedTime;
          if (Keyboard.GetState().IsKeyDown(Keys.Right)) 
            _position += new Vector2(10, 0) * elapsedTime;
          base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
          GraphicsDevice.Clear(Color.CornflowerBlue);
          // Setup the sprite batch matrix      
          // Notice that we first translate to the point or rotation
          // then rotate and when we translate to the desired position we
          // need to compensate for the first translation so that the texture
          // appears at the correct location
          Matrix m = 
            Matrix.CreateScale(1.5f) 
            * Matrix.CreateTranslation(-_rotationPoint.X, -_rotationPoint.Y, 0) 
            * Matrix.CreateRotationZ(_angle) 
            * Matrix.CreateTranslation(_position.X + _rotationPoint.X, _position.Y + _rotationPoint.Y, 0);
          // Begin the SpriteBatch passing the matrix
          spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, m);
          _image1.Draw(spriteBatch);
          _image2.Draw(spriteBatch);            
          spriteBatch.End();
          base.Draw(gameTime);
        }
        class MyImage
        {
          Vector2 _drawOffset;
          Vector2 _sourcePoint;
          Texture2D _sourceTexture;      
          public MyImage(Texture2D sourceTexture, Vector2 sourcePoint, Vector2 drawOffset)
          {
            _drawOffset = drawOffset;
            _sourcePoint = sourcePoint;
            _sourceTexture = sourceTexture;
          }
      
          public void Draw(SpriteBatch spriteBatch)
          {      
            spriteBatch.Draw(_sourceTexture, _drawOffset, 
              new Rectangle((int)_sourcePoint.X, (int)_sourcePoint.Y, 64, 96), 
              Color.White);
          }
        }
      }
    }
