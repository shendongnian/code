    public partial class VideoPanel : UserControl
    {
        private VideoMixingRenderer9 _renderer;
        private IVMRWindowlessControl9 _windowlessControl;
        public VideoMixingRenderer9 Renderer
        {
            get
            {
                return _renderer;
            }
            set
            {
                _renderer = value;
                if (_renderer != null)
                {
                    var filterConfig = _renderer as IVMRFilterConfig9;
                    if (filterConfig != null)
                    {
                        filterConfig.SetRenderingMode(VMR9Mode.Windowless);
                        _windowlessControl = _renderer as IVMRWindowlessControl9;
                        if (_windowlessControl != null)
                        {
                            _windowlessControl.SetVideoClippingWindow(Handle);
                            SetSize();
                        }
                    }
                }
            }
        }
        private void SetSize()
        {
            var srcRect = new DsRect();
            var dstRect = new DsRect(ClientRectangle);
            int arWidth, arHeight;
            _windowlessControl.GetNativeVideoSize(out srcRect.right, out srcRect.bottom, out arWidth, out arHeight);
            _windowlessControl.SetAspectRatioMode(VMR9AspectRatioMode.LetterBox);
            _windowlessControl.SetVideoPosition(srcRect, dstRect);
        }
    }
