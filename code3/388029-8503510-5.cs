	private readonly HashSet<string> mImageIds = new HashSet<string>();
    private readonly ObservableCollection<BitmapImage> mImages = new ObservableCollection<BitmapImage>();
    
    // ... Inside the constructor
    {
    	InitializeComponent();
    	
    	sp_images.ItemsSource = mImages;
    }
    
    public void Instance_GraphicChanged(object sender, PropertyChangedEventArgs e)
    {
        foreach (Model.Graphic item in Model.IncomingCall.Instance.Graphics)
        {
    		// Have we already seen the image
    		if (mImageIds.Add(item.ImageId.ToString()))
    		{
    			// We've not seen the image yet, so add it to the collection
				// Note: We must invoke this on the Dispatcher thread.
				this.Dispatcher.BeginInvoke((Action)delegate()
				{
					mImages.Add(item.ImageObj);
				});
    		}
        }
    }
