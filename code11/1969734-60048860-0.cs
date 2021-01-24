	DXGI.Device1 dxgiDevice1_ = _d3dDevice.QueryInterface<DXGI.Device1>();
	DXGI.Adapter dxgiAdapter_ = dxgiDevice1_.Adapter;
	DXGI.Factory2 dxgiFactory2_ = dxgiAdapter_.GetParent<DXGI.Factory2>();
	ReleaseAllDeviceContexts(true);
	if (_swapChain != null)
	{
		_swapChain.Dispose();
	}
	if (_swapChainBuffer != null)
	{
		_swapChainBuffer.Dispose();
	}
	if (_parentSwapchain != null)
	{
		_parentSwapchain.Dispose();
	}
	#if !WINDOWS_UWP
	DXGI.SwapChainDescription1 swapChainDescription_ = new DXGI.SwapChainDescription1()
	{
		AlphaMode = DXGI.AlphaMode.Ignore,
		Width = _modeDescription.Width,
		Height = _modeDescription.Height,
		Format = DXGI.Format.R8G8B8A8_UNorm,
		Scaling = DXGI.Scaling.None,
		BufferCount = _swapChainBufferCount,
		SwapEffect = SharpDX.DXGI.SwapEffect.FlipDiscard,
		Flags = SharpDX.DXGI.SwapChainFlags.AllowModeSwitch,
		Usage = DXGI.Usage.BackBuffer | DXGI.Usage.RenderTargetOutput,
		SampleDescription = new DXGI.SampleDescription() { Count = 1, Quality = 0 },
		Stereo = false,
	};
	_parentSwapchain1 = new DXGI.SwapChain1(dxgiFactory2_, _d3dDevice, _parentContainer.WindowHandle, ref swapChainDescription_, new DXGI.SwapChainFullScreenDescription()
	{
		RefreshRate = _modeDescription.RefreshRate,
		Scaling = SharpDX.DXGI.DisplayModeScaling.Unspecified,
		Windowed = isFullscreen == false,
		ScanlineOrdering = DXGI.DisplayModeScanlineOrder.Unspecified,
	}
	);
	_swapChain = _parentSwapchain.QueryInterface<DXGI.SwapChain2>();
	#else
	DXGI.SwapChainDescription1 swapChainDescription = new DXGI.SwapChainDescription1()
	{
		AlphaMode = DXGI.AlphaMode.Ignore,
		Width = _modeDescription.Width,
		Height = _modeDescription.Height,
		Format = DXGI.Format.R8G8B8A8_UNorm,
		Scaling = DXGI.Scaling.Stretch,
		BufferCount = _swapChainBufferCount,
		SwapEffect = SharpDX.DXGI.SwapEffect.FlipDiscard,
		Flags = SharpDX.DXGI.SwapChainFlags.AllowModeSwitch | DXGI.SwapChainFlags.AllowTearing,
		Usage = DXGI.Usage.BackBuffer | DXGI.Usage.RenderTargetOutput,
		SampleDescription = new DXGI.SampleDescription() { Count = 1, Quality = 0 },
		Stereo = false,
	};
	ComObject obj = new ComObject(_parentContainer.WindowHandle);
	 _parentSwapchain1 = new DXGI.SwapChain1(dxgiFactory3, _device, ref swapChainDescription, null);
	_swapChain2 = _parentSwapchain1.QueryInterface<DXGI.SwapChain2>();
	using (DXGI.ISwapChainPanelNative nativeObject = ComObject.As<DXGI.ISwapChainPanelNative>(_parentContainer.WindowHandle))
	{
		// Set its swap chain.
		nativeObject.SwapChain = _swapChain2;
	}
	#endif
	_swapChainBuffer = D3D11.Texture2D.FromSwapChain<D3D11.Texture2D>(_swapChain, 0);
	dxgiDevice1_.Dispose();
	dxgiAdapter_.Dispose();
	dxgiFactory2_.Dispose();
	
