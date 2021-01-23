    public partial class TrackTyped : Component
    {
        IContainer components = null;
    
        public TrackTyped()
            : base()
        {
            InitializeComponent();
        }
    
        public TrackTyped(IContainer container)
            : this()
        {
            container.Add(this);
        }
    }
