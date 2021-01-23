    public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		public IEnumerable<Rect> Rectangles
		{
			get 
			{
				yield return new Rect(new Point(10, 10), new Size(100, 100));
				yield return new Rect(new Point(50, 50), new Size(400, 100));
				yield return new Rect(new Point(660, 10), new Size(10, 100));
			}
		}
    }
