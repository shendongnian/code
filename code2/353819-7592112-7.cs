     protected override void Draw(GameTime gameTime)
        {
            virtualScreen.BeginCapture();
            
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            // game rendering happens here...
            virtualScreen.EndCapture();
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            virtualScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
