    public partial class SpinningWait : UserControl
    {
        private Storyboard _storyboard;
        public SpinningWait()
        {
            InitializeComponent();
        }
        public bool IsWaiting
        {
            get { return (bool)GetValue(IsWaitingProperty); }
            set { SetValue(IsWaitingProperty, value); }
        }
        
        public static readonly DependencyProperty IsWaitingProperty =
            DependencyProperty.Register("IsWaiting", typeof(bool), typeof(SpinningWait), new UIPropertyMetadata(false, new PropertyChangedCallback(OnIsWaitingChanged)));
        private static void OnIsWaitingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((SpinningWait)d).OnIsWaitingChanged((object)d, e);
        }
        
        private void OnIsWaitingChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsWaiting)
            {
                this.Visibility = Visibility.Visible;
                this.StartAnimation();
            }
            else
            {
                this.Visibility = Visibility.Collapsed;
                this.StopAnimation();
            }
        }
        private void StartAnimation()
        {
            this._storyboard = (Storyboard)FindResource("canvasAnimation");
            this._storyboard.Begin(canvas, true);
        }
        private void StopAnimation()
        {
            this._storyboard.Remove(canvas);
        }
    }
