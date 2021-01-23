    public interface IImageGenerator
    {
        object FinalImage { get; set; }
    }
    public MyClass : IImageGenerator
    {
        public Image FinalImage{get;set;}
        object IImageGenerator.FinalImage
        {
            get { return FinalImage; }
            set
            {
                if (!(value is Image))
                {
                    throw new ArgumentException("Must be an image");
                }
                FinalImage = (Image) value;
            }
        }
    }
