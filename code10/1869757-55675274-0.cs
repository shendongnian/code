    public partial class MethodHolderBasic : UserControl
    {
        public Bitmap ExpandedImgage;
        public Bitmap CollaspedImage;
        bool _expanded = false;
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Category("u4sSearchBox")]
        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                _expanded = value;
                if (_expanded)
                    pbExpand.Image = new Bitmap(ExpandedImgage, 22, 22);
                else
                    pbExpand.Image = new Bitmap(CollaspedImage, 22, 22);
            }
        }
        public MethodHolderBasic()
        {
            InitializeComponent();
            pbDelete.Image = new Bitmap(pbDelete.Image, 22, 22);
            pbExpand.Image = new Bitmap(pbExpand.Image, 22, 22);
            // Initialize ExpandedImgage and CollaspedImage
            ExpandedImgage = new Bitmap(pbDelete.Image, 22, 22);
            CollaspedImage = new Bitmap(pbExpand.Image, 22, 22);
        }
    }
