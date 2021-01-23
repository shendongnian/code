    public partial class RectangleView : UserControl
	{
		public RectangleView()
		{
			InitializeComponent();
		}
		protected override void OnRender(DrawingContext drawingContext)
		{
			base.OnRender(drawingContext);
			drawingContext.DrawRectangle(Brushes.Orchid, new Pen(Brushes.OliveDrab, 2.0), (Rect)this.DataContext);
		}
		protected override void OnMouseDown(MouseButtonEventArgs e)
		{
            // HERE YOU CAN PROCCESS MOUSE CLICK
			base.OnMouseDown(e);
		}
	}
