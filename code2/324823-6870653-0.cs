    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace StencilTest
    {
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
    
            Texture2D star, cloud, shape;
            AlphaTestEffect alphaTestEffect;
            DepthStencilState stencilAlways;
            DepthStencilState stencilKeep;
            RenderTarget2D rt;
    
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
    
                graphics.PreferredDepthStencilFormat = DepthFormat.Depth24Stencil8;
    
                graphics.PreferredBackBufferWidth = 800;
                graphics.PreferredBackBufferHeight = 600;
    
                IsMouseVisible = true;
            }
    
            protected override void Initialize()
            {
                base.Initialize();
            }
    
            Texture2D grass;
    
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
                star = Content.Load<Texture2D>("star1");
                cloud = Content.Load<Texture2D>("cloud1");
                shape = Content.Load<Texture2D>("shape");
                back = Content.Load<Texture2D>("back");
                grass = Content.Load<Texture2D>("grass1");
    
                Matrix projection = Matrix.CreateOrthographicOffCenter(0, shape.Width, shape.Height, 0, 0, 1);
                Matrix halfPixelOffset = Matrix.CreateTranslation(-0.5f, -0.5f, 0);
    
                alphaTestEffect = new AlphaTestEffect(GraphicsDevice);
                alphaTestEffect.VertexColorEnabled = true;
                alphaTestEffect.DiffuseColor = Color.White.ToVector3();
                alphaTestEffect.AlphaFunction = CompareFunction.Equal;
                alphaTestEffect.ReferenceAlpha = 0;
                alphaTestEffect.World = Matrix.Identity;
                alphaTestEffect.View = Matrix.Identity;
                alphaTestEffect.Projection = halfPixelOffset * projection;
    
                // set up stencil state to always replace stencil buffer with 1
                stencilAlways = new DepthStencilState();
                stencilAlways.StencilEnable = true;
                stencilAlways.StencilFunction = CompareFunction.Always;
                stencilAlways.StencilPass = StencilOperation.Replace;
                stencilAlways.ReferenceStencil = 1;
                stencilAlways.DepthBufferEnable = false;
    
                // set up stencil state to pass if the stencil value is 1
                stencilKeep = new DepthStencilState();
                stencilKeep.StencilEnable = true;
                stencilKeep.StencilFunction = CompareFunction.Equal;
                stencilKeep.StencilPass = StencilOperation.Keep;
                stencilKeep.ReferenceStencil = 1;
                stencilKeep.DepthBufferEnable = false;
    
                rt = new RenderTarget2D(GraphicsDevice, shape.Width, shape.Height,
                                       false, SurfaceFormat.Color, DepthFormat.Depth24Stencil8,
                                       0, RenderTargetUsage.DiscardContents);
            }
    
            protected override void UnloadContent()
            {
    
            }
    
            protected override void Update(GameTime gameTime)
            {
                // Allows the game to exit
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    this.Exit();
    
                // TODO: Add your update logic here
    
                base.Update(gameTime);
            }
    
            float angle = 0f;
            private Texture2D back;
            Vector2 pos = new Vector2(400, 300);
            float cloudscale = 0.25f;
    
            protected override void Draw(GameTime gameTime)
            {
    
                // set up rendering to the active render target
                GraphicsDevice.SetRenderTarget(rt);
    
                // clear the render target to opaque black,
                // and initialize the stencil buffer with all zeroes
                GraphicsDevice.Clear(ClearOptions.Target | ClearOptions.Stencil,
                                     new Color(0, 0, 0, 1), 0, 0);
    
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque,
                           null, stencilAlways, null, alphaTestEffect);
    
                spriteBatch.Draw(shape, Vector2.Zero, null, Color.White, 0f,
                                 Vector2.Zero, 1f, SpriteEffects.None, 0f);
    
                spriteBatch.End();
    
                spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend,
                      null, stencilKeep, null, null);
    
                //for (int i = 0; i < Math.Ceiling(800 / (cloud.Width * cloudscale)); i++)
                //    for (int j = 0; j < Math.Ceiling(600 / (cloud.Height * cloudscale)); j++)
                //        spriteBatch.Draw(cloud, Vector2.Zero + new Vector2(i * cloud.Width * cloudscale, j * cloud.Height * cloudscale), null, Color.White, 0f,
                //         Vector2.Zero, cloudscale, SpriteEffects.None, 0f);
    
                spriteBatch.Draw(grass, new Vector2(rt.Width / 2, rt.Height / 2) + new Vector2(0f, -100f), null, Color.White, 0f,
             new Vector2(grass.Width / 2, grass.Height / 2), .85f, SpriteEffects.None, 0f);
    
                spriteBatch.Draw(cloud, new Vector2(rt.Width/2, rt.Height/2), null, Color.White, 0f,
                         new Vector2(cloud.Width / 2, cloud.Height / 2), 1f, SpriteEffects.None, 0f);
    
                spriteBatch.Draw(star, new Vector2(rt.Width / 2, rt.Height / 2) + new Vector2(0f, 100f), null, Color.White, 0f,
             new Vector2(star.Width / 2, star.Height / 2), .85f, SpriteEffects.None, 0f);
    
                spriteBatch.End();
    
                GraphicsDevice.SetRenderTarget(null);
    
                spriteBatch.Begin();
    
                spriteBatch.Draw(back, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
    
                spriteBatch.Draw(rt, pos + new Vector2(50f * (float)Math.Cos(MathHelper.ToRadians(angle)), 50f * (float)Math.Sin(MathHelper.ToRadians(angle))), null, Color.White, 0f, new Vector2(rt.Width / 2, rt.Height / 2), 1f, SpriteEffects.None, 0f);
    
                spriteBatch.End();
    
                // TODO: Add your drawing code here
    
                angle +=0.5f;
    
                base.Draw(gameTime);
            }
        }
    }
