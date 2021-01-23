    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);
        }
    
        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            Rectangle smoke = new Rectangle();
            LayoutRoot.Children.Add(smoke);
            smoke.Y -= 5;
        }
    }
