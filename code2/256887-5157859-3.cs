    public partial class ImageButton : UserControl
    {
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image",
                typeof(ImageSource),
                typeof(ImageButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public ImageSource Image
        {
            get { return (ImageSource)base.GetValue(ImageProperty); }
            set { base.SetValue(ImageProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text",
                typeof(string),
                typeof(ImageButton),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsMeasure));
        public string Text
        {
            get { return (string)base.GetValue(TextProperty); }
            set { base.SetValue(TextProperty, value); }
        }
        //...
    }
