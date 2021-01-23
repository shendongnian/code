    Rendertarget2D offscreenRT = new RenderTarget2D(_device, width, height);
    _device.SetRenderTarget(offscreenRT);
    _device.Clear(Color.Transparent);
    
    SpriteBatch  spriteBatch = new SpriteBatch(_device);
    spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
    spriteBatch.Draw(buffer, Vector2.Zero, Color.White);
    spriteBatch.End();
    _device.SetRenderTarget(null);
