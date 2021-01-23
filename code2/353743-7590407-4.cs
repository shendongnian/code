    public MyObject()
    {    
       MyImageObject.Update += new UpdateEventHandler(ImageDataUpdated); 
    }
    private void ImageDataUpdated(object sender, EventArgs e) 
    {
        // do stuff
    }
