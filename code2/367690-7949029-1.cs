      spriteBatch.GraphicsDevice.RenderState.ScissorTestEnable = true;
      spriteBatch.GraphicsDevice.ScissorRectangle = myTextBox.GetRectangle();
      spriteBacth.Begin();
      spriteBatch.DrawString(...);       
      spriteBacth.End();
      spriteBatch.GraphicsDevice.RenderState.ScissorTestEnable = false;      
      
