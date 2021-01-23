    //accessible to the code-front
    protected List<Image> Images {get; private set; }
    //nested class also accessible to the code-front
    protected class Image
    {
        public string tnImg { get; set; }
        public string Name { get; set; }
        public string city { get; set; }
        public string refPlace { get; set; }
        public string refInfo { get; set; }
        public string refInfoDynamic { get; set; }
    }
    //exactly the reason why by default Page_Load is protected
    protected void Page_Load(object sender, EventArgs e)
    {
        getImgCarousel();
    }
    //this should be private as will not be called by anything outside the class
    private void getImgCarousel()
    {
        //uses the property
        Images = new List<Image>();
        var carouselImages = new Image();
        carouselImages.Name = "test";
        var carouselImages2 = new Image();
        carouselImages2.Name = "test2";
        Images.Add(carouselImages);
        Images.Add(carouselImages2);
    }
