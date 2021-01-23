	PresentationParameters pp = globals.graphics_device.PresentationParameters;
	byte width = 20, height = 20; // for example
	
	// pp.BackBufferWidth, pp.BackBufferHeight // for auto x and y sizes
	RenderTarget2D render_target = new RenderTarget2D(globals.graphics_device,
	width, height, false, pp.BackBufferFormat, pp.DepthStencilFormat,
	pp.MultiSampleCount, RenderTargetUsage.DiscardContents);
	
	graphicsDevice.SetRenderTarget(render_target);
	graphicsDevice.Clear(...); // possibly optional
	spriteBatch.Begin();
	// draw to the spriteBatch
	spriteBatch.End();
	graphicsDevice.SetRenderTarget(null); // Otherwise the SpriteBatch can't
	// be used as a texture, this may also need to be done before using the
	// SpriteBatch normally again to render to the screen.
	
	// render_target can now be used as a Texture2D
