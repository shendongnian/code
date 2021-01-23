    void selectedImageClick(object sender, MouseButtonEventArgs e)
    {
        Image img = sender as Image;
        if (img != null)  // In case someone calls this event handler with something other than an Image
        {
            //Modify that image e.g: border
        }
    }
