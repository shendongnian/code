     protected override void Draw(GameTime gameTime)
        {
            virtualScreen.BeginCapture();
            
            // game rendering happens here...
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            virtualScreen.EndCapture();
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            virtualScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
