    void RemoveLastImage(ImageList imageList)
    {
        var lastIndex = imageList.Images.Count - 1;
        var lastImage = imageList.Images[lastIndex];
        imageList.Images.RemoveAt(lastIndex);
        lastImage.Dispose();
    }
    while (imageList1.Images.Count > 3)
    {
        RemoveLastImage(imageList1);
    }
