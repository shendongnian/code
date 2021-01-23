	/// <summary>
	/// Interaction logic for EyeDemo.xaml
	/// </summary>
	public partial class EyeDemo : UserControl
	{
		public EyeDemo()
		{
			this.InitializeComponent();
			double majorRadius = Eye.Width / 2d;
			double minorRadius = Eye.Height / 2d;
			Point center = new Point( Canvas.GetLeft( Eye ) + majorRadius, Canvas.GetTop( Eye ) + minorRadius );
			// create event streams for mouse down/up/move using reflection
			// to keep taking mouse move events and return the X, Y positions
			var mouseMove = from evt in Observable.FromEvent<MouseEventArgs>( LayoutRoot, "PreviewMouseMove" )
							select (Point?)evt.EventArgs.GetPosition( this );
			// subscribe to the stream of position changes and modify the Canvas.Left and Canvas.Top
			// use the bound by elipse function to restrain the pupil to with the eye.
			mouseMove.BufferWithTime( TimeSpan.FromMilliseconds( 10 ) ).Select( p => BoundByElipse( majorRadius, minorRadius, center, p.LastOrDefault() ) )
				.ObserveOnDispatcher().Subscribe( pos =>
				  {
					  if( pos.HasValue )
					  {
						  Canvas.SetLeft( Pupil, pos.Value.X - Pupil.Width / 2d );
						  Canvas.SetTop( Pupil, pos.Value.Y - Pupil.Height / 2d );
					  }
				  } );
		}
		private Point? BoundByElipse( double majorRadius, double minorRadius, Point center, Point? point )
		{
			if( point.HasValue )
			{
				// Formular for an elipse is  x^2 / a^2 + y^2 / b^2 = 1
				// where a = majorRadius and b = minorRadius
				// Using this formular we can work out if the point is with in the elipse 
				// or find the boundry point closest to the point
				// Find the location of the point relative to the center.
				Point p = new Point( point.Value.X - center.X, point.Value.Y - center.Y );
				double a = majorRadius;
				double b = minorRadius;
				double f = p.X * p.X / (a * a) + p.Y * p.Y / (b * b);
				if( f <= 1 )
				{
					// the point is with in the elipse;
					return point;
				}
				else
				{
					// the point is outside the elipse, therefore need to find the closest location on the boundry.
					double xdirection = point.Value.X > center.X ? 1 : -1;
					double ydirection = point.Value.X > center.X ? 1 : -1;
					double r = p.X / p.Y;
					double x = p.Y != 0 ? Math.Sqrt( r * r * a * a * b * b / (r * r * b * b + a * a) ) : a;
					double y = r != 0 ? x / r : b;
					return new Point( center.X + xdirection * x, center.Y + ydirection * y );
				}
			}
			else
			{
				return null;
			}
		}
	}
