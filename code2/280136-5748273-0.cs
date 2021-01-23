    public void Fetch(Uri uri)
    {
    	WebClient webClient = new WebClient();
    	webClient.OpenReadCompleted += this.ReadCompleted;
    	webClient.OpenReadAsync(uri);
    }
    
    private void ReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
    	WebClient webClient = (WebClient)sender;
    	webClient.OpenReadCompleted -= this.ReadCompleted;
    	Stream stream = e.Result;
    	BitmapImage bmp = new BitmapImage();
    	bmp.SetSource(stream);
    	WriteableBitmap wbmp = new WriteableBitmap(bmp);
    }
