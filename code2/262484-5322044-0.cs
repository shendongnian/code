    class LayerItem
    {
        public string Name { get; set; }
    
        public event EventHandler ItemEvent;
        protected virtual void OnItemEvent(EventArgs e)
        {
        if (this.ItemEvent != null)
            this.ItemEvent(this, e);
        }
    }
    
    class ImageLayerItem : LayerItem
    {
        private Image _image;
    
        public ImageLayerItem()
        {
            //here create Image element and think of rendering it.
            _image = new Image();
            //attach event handlers.
            _image.Click += ... //don't forget to call LayerItem.OnItemEvent() inside the event handler.
        }
    }
