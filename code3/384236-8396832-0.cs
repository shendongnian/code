    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    
    namespace WindowsGame1
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
    
            float AspectRatio;
            Point OldWindowSize;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
    
                graphics.IsFullScreen = false;
                Window.AllowUserResizing = true;
                Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            }
    
            void Window_ClientSizeChanged(object sender, EventArgs e)
            {
                // Remove this event handler, so we don't call it when we change the window size in here
                Window.ClientSizeChanged -= new EventHandler<EventArgs>(Window_ClientSizeChanged);
    
                if(Window.ClientBounds.Width != OldWindowSize.X)
                { // We're changing the width
                    // Set the new backbuffer size
                    graphics.PreferredBackBufferWidth = Window.ClientBounds.Width;
                    graphics.PreferredBackBufferHeight = (int)(Window.ClientBounds.Width / AspectRatio);
                    // apply our changes which updates the window size
                    graphics.ApplyChanges();
                }
                else if(Window.ClientBounds.Height != OldWindowSize.Y)
                { // we're changing the height
                    // Set the new backbuffer size
                    graphics.PreferredBackBufferHeight = Window.ClientBounds.Width;
                    graphics.PreferredBackBufferWidth = (int)(Window.ClientBounds.Height * AspectRatio);
                    // apply our changes which updates the window size
                    graphics.ApplyChanges();
                }
    
                // Update the old window size with what it is currently
                OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
    
                // add this event handler back
                Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            }
    
            protected override void LoadContent()
            {
                // Set up initial values
                AspectRatio = Window.ClientBounds.Width / (float)Window.ClientBounds.Height;
                OldWindowSize = new Point(Window.ClientBounds.Width, Window.ClientBounds.Height);
            }
    
            protected override void Draw(GameTime gameTime)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                base.Draw(gameTime);
            }
        }
    }
