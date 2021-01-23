    public List<productImage> productImages = new List<productImage>();
    productImage newImage = new productImage();
    newImage.imageID = 123;
    productImages.Add(newImage);
    int something = productImages[0].imageID;  // Works
