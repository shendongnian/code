    public class FooGame : Game
    {
        ... 
        private void SetWindow(bool fullscreen)
        {
            if(!fullscreen)
            {
                System.Windows.Forms.Application.EnableVisualStyles();
            }
            this.graphicsDeviceManager.IsFullScreen = fullscreen;
            this.graphicsDeviceManager.ApplyChanges();
        }
    }
