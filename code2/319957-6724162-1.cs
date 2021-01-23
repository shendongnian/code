    public partial class TrackTyped : Component
    {
        IContainer components = null; 
        public TrackTyped() : base()
        {
            // logic for InitializeComponent() here
        } 
        
        public TrackTyped(IContainer container) : this()
        {
            container.Add(this)
        }
    }
