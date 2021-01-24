               public void ResizeBuffers(bool isFullscreen)
            {
                try
                {
                    if (_swapChainBuffer != null)
                    {
                        //      if (_parentSwapchain1.IsFullScreen != isFullscreen)
                        {
                            ReleaseAllDeviceContexts(true);
    
                            SharpDX.Utilities.Dispose(ref _swapChain2);
                            SharpDX.Utilities.Dispose(ref _swapChainBuffer);
    
    #if !WINDOWS_UWP
                            _parentSwapchain1.IsFullScreen = isFullscreen;
    
                            _parentSwapchain1.ResizeBuffers(0, _modeDescription.Width, _modeDescription.Height, DXGI.Format.Unknown, SharpDX.DXGI.SwapChainFlags.AllowModeSwitch);
                            if (isFullscreen)
                            {
                                _parentSwapchain1.ResizeTarget(ref _modeDescription);
                            }
    #else
                            _parentSwapchain1.ResizeBuffers(0, _modeDescription.Width, _modeDescription.Height, DXGI.Format.Unknown, DXGI.SwapChainFlags.AllowTearing);
    #endif
    
                            _swapChain2 = _parentSwapchain1.QueryInterface<DXGI.SwapChain2>();
    
                            _swapChainBuffer = D3D11.Texture2D.FromSwapChain<D3D11.Texture2D>(_swapChain2, 0);
                        }
                        _renderViewport = new Viewport(0, 0, _modeDescription.Width, _modeDescription.Height);
                        _d3dDevice.ImmediateContext1.Rasterizer.SetViewport(_renderViewport);
                    }
    
                }
                catch (Exception ex)
                {
                    ErrorHandler.DoErrorHandling(ex, ErrorHandler.GetCurrentMethod(ex));
                }
    
            }
