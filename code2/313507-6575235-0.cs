    public partial class Listing : UserControl
    {
        public Listing()
        {
            InitializeComponent();
            SizeChanged += OnSizeChanged;
        }
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            // split if control is not loaded yet
            if (!dgProject.IsLoaded) return;
            // only interested in width, not height
            if (!e.WidthChanged) return;
            var delta = e.NewSize.Width - e.PreviousSize.Width;
            var newWidth = colDescription.ActualWidth + delta;
            if (newWidth <= colDescription.MinWidth || newWidth >= colDescription.MaxWidth) return;
            colDescription.Width = new DataGridLength(newWidth);
        }
