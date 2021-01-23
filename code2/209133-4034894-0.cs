    // readonly property - will throw null reference if not initialized
    public IList<Image> Images { get;}
    public void getImgCarousel()
    {
        this.Images = new List<Image>();
        var carouselImages = new Image();
        carouselImages.Name = "test";
        var carouselImages2 = new Image();
        carouselImages2.Name = "test2";
        Images.Add(carouselImages);
        Images.Add(carouselImages2);
    }
