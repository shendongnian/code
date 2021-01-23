    public class ImageButtonItem: ToolStripControlHost
    {
        private ImageButton imgButton;
    
        public ImageButtonItem()
            : base(new ImageButton())
        {
            this.imgButton = this.Control as ImageButton;
        }
    
        // Add properties, events etc. you want to expose...
    }
