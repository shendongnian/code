    [Export("HelloWorldView")]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public partial class HelloWorldView : UserControl
    {
        public HelloWorldView()
        {
            InitializeComponent();
        }
    }
