    public partial class ImageCheckBox // NameSpace: MyControls
    {
        public ImageCheckBox()
        {
            InitializeComponent();
        }
    
        public const string CheckedImagePathPropertyName = "CheckedImagePath";
        
        public Uri CheckedImagePath
        {
            get
            {
                return (Uri)GetValue(CheckedImagePathProperty);
            }
            set
            {
                SetValue(CheckedImagePathProperty, value);
            }
        }
    
        public static readonly DependencyProperty CheckedImagePathProperty =
            DependencyProperty.Register(CheckedImagePathPropertyName,
                typeof(Uri), typeof(ImageCheckBox), new PropertyMetadata(null));
    
        public const string UnCheckedImagePathPropertyName = "UnCheckedImagePath";
        
        public Uri UnCheckedImagePath
        {
            get
            {
                return (Uri)GetValue(UnCheckedImagePathProperty);
            }
            set
            {
                SetValue(UnCheckedImagePathProperty, value);
            }
        }
    
        public static readonly DependencyProperty UnCheckedImagePathProperty =
            DependencyProperty.Register(UnCheckedImagePathPropertyName, 
                typeof(Uri), typeof(ImageCheckBox), new PropertyMetadata(null));
    }
