	public void DrawCustomScrollButton (Graphics aG, Int32 aX, Int32 aY, Int32 aWidth, Int32 aHeight,
		Image aImage, Int32 aState)
	{
		Rectangle R = new Rectangle(aX, aY, aX + aWidth, aY + aHeight);
		VisualStyleRenderer Renderer = new VisualStyleRenderer
		(
			VisualStyleElement.ScrollBar.ThumbButtonHorizontal.Normal
		);
		Renderer.DrawBackground(G, R);
		if (aImage != null)
		{
			aG.DrawImage(aImage,
				aX + ((ScrollBarHeight - aImage.Width	) / 2),
				aY + ((ScrollBarHeight - aImage.Height	) / 2));
		}
	}
