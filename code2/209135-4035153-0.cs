    // Make the list protected
    protected List<Image> Images;
    // Make the class protected
    protected class Image
    {
    	...
    }
    
    protected void Page_Load( object sender, EventArgs e )
    {
    	...
    }
    
    public void getImgCarousel()
    {
        // Assign to the protected field.
    	Images = new List<Image>();
    
    	...
    }
