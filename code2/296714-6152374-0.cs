    string imageUrl = "";
    // Create the requests.
    WebRequest requestPic = WebRequest.Create(imageUrl);
    WebResponse responsePic = requestPic.GetResponse();
    Image webImage = Image.FromStream(responsePic.GetResponseStream());
    
    // save image
    webImage.Save("C:\\image.jpg");
    	
    ImageList imgList;
    imgList.Images.Add(webImage);
    ListView1.LargeImageList = imgList;
