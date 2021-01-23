      VirtualScreen virtualScreen;
        protected override void Initialize()
        {
            virtualScreen = new VirtualScreen(96, 54, GraphicsDevice);
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);
            Window.AllowUserResizing = true;
            base.Initialize();
        }
        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            virtualScreen.PhysicalResolutionChanged();
        }
