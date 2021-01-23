    public static class MyGraphics{
        public static readonly GraphicsDeviceManager DeviceManager = new GraphicsDeviceManager();
        
        public int ScreenWidth{
            get{ return DeviceManager.Viewport.TitleSafeArea.Width; }
        }
    }
