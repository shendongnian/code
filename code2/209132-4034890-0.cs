    List<Image> images = new List<Image>();
    protected List<Image> Images
    {
        get { return this.images; }
    }
    public void getImgCarousel()
    {
        var carouselImages = new Image();
        carouselImages.Name = "test";
        var carouselImages2 = new Image();
        carouselImages2.Name = "test2";
        Images.Add(carouselImages);
        Images.Add(carouselImages2);
    }
