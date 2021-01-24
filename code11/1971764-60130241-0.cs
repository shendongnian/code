    public partial class HomeView : UserControl
    {
        private Storyboard _mouseEnterStoryboard;
        private Storyboard _mouseLeaveStoryboard;
        private DoubleAnimation _scaleX_In;
        private DoubleAnimation _scaleY_In;
        private DoubleAnimation _scaleX_Out;
        private DoubleAnimation _scaleY_Out;
        public HomeView()
        {
            InitializeComponent();
            _mouseEnterStoryboard = new Storyboard();
            ScaleTransform scaleVaultsButton = new ScaleTransform(1.0, 1.0);
            ScaleTransform scaleFilesButton = new ScaleTransform(1.0, 1.0);
            VaultsButton.RenderTransformOrigin = new Point(0.5, 0.5);
            VaultsButton.RenderTransform = scaleVaultsButton;
            FilesButton.RenderTransformOrigin = new Point(0.5, 0.5);
            FilesButton.RenderTransform = scaleFilesButton;
            _scaleX_In = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(100),
                From = 1.0,
                To = 1.08
            };
            _scaleY_In = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(100),
                From = 1.0,
                To = 1.08
            };
            _mouseEnterStoryboard.Children.Add(_scaleX_In);
            _mouseEnterStoryboard.Children.Add(_scaleY_In);
            Storyboard.SetTargetProperty(_scaleX_In, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(_scaleY_In, new PropertyPath("RenderTransform.ScaleY"));
            _mouseLeaveStoryboard = new Storyboard();
            _scaleX_Out = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(100),
                From = 1.08,
                To = 1.0
            };
            _scaleY_Out = new DoubleAnimation()
            {
                Duration = TimeSpan.FromMilliseconds(100),
                From = 1.08,
                To = 1.0
            };
            _mouseLeaveStoryboard.Children.Add(_scaleX_Out);
            _mouseLeaveStoryboard.Children.Add(_scaleY_Out);
            Storyboard.SetTargetProperty(_scaleX_Out, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(_scaleY_Out, new PropertyPath("RenderTransform.ScaleY"));
            VaultsButton.MouseEnter += new MouseEventHandler(Button_MouseEnter);
            VaultsButton.MouseLeave += new MouseEventHandler(Button_MouseLeave);
            FilesButton.MouseEnter += new MouseEventHandler(Button_MouseEnter);
            FilesButton.MouseLeave += new MouseEventHandler(Button_MouseLeave);
        }
        public void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard.SetTarget(_scaleX_In, (Button)sender);
            Storyboard.SetTarget(_scaleY_In, (Button)sender);
            _mouseEnterStoryboard.Begin();
        }
        public void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard.SetTarget(_scaleX_Out, (Button)sender);
            Storyboard.SetTarget(_scaleY_Out, (Button)sender);
            _mouseLeaveStoryboard.Begin();
        }
    }
