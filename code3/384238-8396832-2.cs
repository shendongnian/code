    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace WindowsGame1
    {
        public class Game1 : Game
        {
            GraphicsDeviceManager Graphics;
            float AspectRatio;
            Point OldWindowSize;
            Texture2D BlankTexture;
            RenderTarget2D OffScreenRenderTarget;
            SpriteBatch SpriteBatch;
    
            public Game1()
            {
                Graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
    
                Graphics.IsFullScreen = false;
                Window.AllowUserResizing = true;
                Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            }
    
            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                // Remove this event handler, so we don't call it when we change the window size in here
                Window.ClientSizeChanged -= new EventHandler<EventArgs>(Window_ClientSizeChanged);
    
                if (Window.ClientBounds.Width != OldWindowSize.X)
                { // We're changing the width
                    // Set the new backbuffer size
                    Graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                    Graphics.PreferredBackBufferHeight = (int)(Window.ClientBounds.Width / AspectRatio);
                }
                else if (Window.ClientBounds.Height != OldWindowSize.Y)
                { // we're changing the height
                    // Set the new backbuffer size
                    Graphics.PreferredBackBufferWidth = (int)(Window.ClientBounds.Height * AspectRatio);
                    Graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
                }
    
                Graphics.ApplyChanges();
    
                // Update the old window size with what it is currently
                OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
    
                // add this event handler back
                Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            }
    
            protected override void LoadContent()
            {
                // Set up initial values
                AspectRatio = GraphicsDevice.Viewport.AspectRatio;
                OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
    
                BlankTexture = new Texture2D(GraphicsDevice, 1, 1);
                BlankTexture.SetData(new Color[] { Color.FromNonPremultiplied(255, 255, 255, 255) });
                SpriteBatch = new SpriteBatch(GraphicsDevice);
    
                OffScreenRenderTarget = new RenderTarget2D(GraphicsDevice, Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
    
            protected override void UnloadContent()
            {
                if (OffScreenRenderTarget != null)
                    OffScreenRenderTarget.Dispose();
    
                if (BlankTexture != null)
                    BlankTexture.Dispose();
    
                if (SpriteBatch != null)
                    SpriteBatch.Dispose();
                
                base.UnloadContent();
            }
    
            protected override bool BeginDraw()
            {
                GraphicsDevice.SetRenderTarget(OffScreenRenderTarget);
                return base.BeginDraw();
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                SpriteBatch.Begin();
                SpriteBatch.Draw(BlankTexture, new Rectangle(100, 100, 100, 100), Color.White);
                SpriteBatch.End();
                base.Draw(gameTime);
            }
    
            protected override void EndDraw()
            {
                GraphicsDevice.SetRenderTarget(null);
                SpriteBatch.Begin();
                SpriteBatch.Draw(OffScreenRenderTarget, GraphicsDevice.Viewport.Bounds, Color.White);
                SpriteBatch.End();
                base.EndDraw();
            }
        }
    }
