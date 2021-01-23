    class VirtualScreen
    {
        public readonly int VirtualWidth;
        public readonly int VirtualHeight;
        public readonly float VirtualAspectRatio;
        private GraphicsDevice graphicsDevice;
        private RenderTarget2D screen;
        public VirtualScreen(int virtualWidth, int virtualHeight, GraphicsDevice graphicsDevice)
        {
            VirtualWidth = virtualWidth;
            VirtualHeight = virtualHeight;
            VirtualAspectRatio = (float)(virtualWidth) / (float)(virtualHeight);
            this.graphicsDevice = graphicsDevice;
            screen = new RenderTarget2D(graphicsDevice, virtualWidth, virtualHeight, false, graphicsDevice.PresentationParameters.BackBufferFormat, graphicsDevice.PresentationParameters.DepthStencilFormat, graphicsDevice.PresentationParameters.MultiSampleCount, RenderTargetUsage.DiscardContents);
        }
        private bool areaIsDirty = true;
        public void PhysicalResolutionChanged()
        {
            areaIsDirty = true;
        }
        private Rectangle area;
        public void Update()
        {
            if (!areaIsDirty)
            {
                return;
            }
            areaIsDirty = false;
            var physicalWidth = graphicsDevice.Viewport.Width;
            var physicalHeight = graphicsDevice.Viewport.Height;
            var physicalAspectRatio = graphicsDevice.Viewport.AspectRatio;
            if ((int)(physicalAspectRatio * 10) == (int)(VirtualAspectRatio * 10))
            {
                area = new Rectangle(0, 0, physicalWidth, physicalHeight);
                return;
            }
            if (VirtualAspectRatio > physicalAspectRatio)
            {
                var scaling = (float)physicalWidth / (float)VirtualWidth;
                var width = (float)(VirtualWidth) * scaling;
                var height = (float)(VirtualHeight) * scaling;
                var borderSize = (int)((physicalHeight - height) / 2);
                area = new Rectangle(0, borderSize, (int)width, (int)height);
            }
            else
            {
                var scaling = (float)physicalHeight / (float)VirtualHeight;
                var width = (float)(VirtualWidth) * scaling;
                var height = (float)(VirtualHeight) * scaling;
                var borderSize = (int)((physicalWidth - width) / 2);
                area = new Rectangle(borderSize, 0, (int)width, (int)height);
            }
        }
        public void BeginCapture()
        {
            graphicsDevice.SetRenderTarget(screen);
        }
        public void EndCapture()
        {
            graphicsDevice.SetRenderTarget(null);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(screen, area, Color.White);
        }
    }
