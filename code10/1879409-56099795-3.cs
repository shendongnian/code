    private List<BitmapResource> BitmapResources = null;
    public Form1()
    {
        InitializeComponent();
    
        this.BitmapResources = new List<BitmapResource>()
        {
            new BitmapResource(new Bitmap(Properties.Resources._4), "Logo"),
            new BitmapResource(new Bitmap(Properties.Resources._5), "Watermark")
        };
    }
    internal class BitmapResource
    {
        public BitmapResource(Bitmap bitmap, string imageName)
        {
            this.Image = bitmap;
            this.Name = imageName;
        }
        public Bitmap Image { get; private set; }
        public string Name { get; private set; }
    }
