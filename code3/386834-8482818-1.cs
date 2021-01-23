	public partial class AnimatableScrollViewer : UserControl
	{
        public static readonly DependencyProperty AnimatablOffsetProperty = DependencyProperty.Register("AnimatableOffset",
        	typeof(double), typeof(AnimatableScrollViewer), new PropertyMetadata(AnimatableOffsetPropertyChanged));
        public double AnimatableOffset
        {
            get { return (double)this.GetValue(AnimatablOffsetProperty); }
            set { this.SetValue(AnimatablOffsetProperty, value); }
        }
		public AnimatableScrollViewer()
		{
			InitializeComponent();
            AnimatableOffset = scrollViewer.VerticalOffset;
		}
        private static void AnimatableOffsetPropertyChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            AnimatableScrollViewer cThis = sender as AnimatableScrollViewer;
            cThis.scrollViewer.ScrollToVerticalOffset((double)args.NewValue);
        }
	}
