	// Define custom EventArgs to pass into the Move event
	public class MoveEventArgs : EventArgs
	{
		private Point _movePoint;
		public MoveEventArgs(Point movePoint)
		{
			_movePoint = _movePoint;
		}
		
		public Point MovePoint { get { return _movePoint; } } 
	}
	// Define a custom user control that raises an event to subscribers on move
	public class MyUserControl : UserControl
	{
		public event EventHandler<MoveEventArgs> Moved;
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			e.Handled = true;
			if (e.KeyCode == Keys.Left)
			{
				Move(pt.X,pt.Y);//Move is a function within the usercontrol
				OnMoved(pt);
			}	
			else if (e.KeyCode == Keys.Right)
			{
				Move(pt.X,pt.Y);
				OnMoved(pt);
			}
		   //other conditions
		   e.Handled = false;
		}
		
		// Raises a custom event, Moved 
		protected void OnMoved(Point movePoint)
		{
			var handler = Moved;
			if (handler != null)
			{
				handler(this, new MoveEventArgs(movePoint);
			}
		}
	}
	// How to subscribe to the event (and be notified of move)
	public class MyParentForm : Form
	{
		public MyParentForm()
		{
			InitializeComponent();
			_myUserControl.Moved += new EventHandler<MoveEventArgs>(MyUserControl_Moved);
		}
		
		private void MyUserControl_Moved(object sender, MoveEventArgs e)
		{
			// e.MovePoint now contains the point that the usercontrol was moved to
			// this event will fire whenever the user presses Left or Right arrow
		}
	}
