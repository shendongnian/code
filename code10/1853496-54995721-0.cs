	protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
	{
		base.OnRenderSizeChanged(sizeInfo);
		theRect.Width = sizeInfo.NewSize.Width;
		theRect.Height = sizeInfo.NewSize.Width * 6 / 9;
	}
