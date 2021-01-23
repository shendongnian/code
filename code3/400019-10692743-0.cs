    // Set image url
    string imgURL = ("http://cdn.flikr.com/images/products/" + imageName);
    
    // Get image into memory
    WebClient lWebClient = new WebClient();
    byte[] lImageBytes = lWebClient.DownloadData(imgURL);
    MemoryStream imgStream = new MemoryStream(lImageBytes);
       
    image = System.Drawing.Image.FromStream(imgStream);
    
    if (image.Width >= 200)
    {
    	// do something
    }
