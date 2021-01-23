    /// <summary>
	/// This class is intended to beat the AutoSize and AutoScroll features into submission!
	/// 
	/// Or, at least getting them to work the way I want them to (which may not be the way 
	/// others think they should work).
	/// 
	/// This class will force a panel that has AutoSize enabled to actually increase its
	/// width as appropriate when the AutoScroll Vertical scroll bar becomes visible.
	/// I like this better than attempting to 'reserve' space for the Vertical scroll bar,
	/// which wastes space when the scroll bar is not needed, and leaves ugly gaps in
	/// your user interface.
	/// </summary>
	public class AutoScrollFixer
	{
		/// <summary>
		/// This is the panel we are 'fixing'
		/// </summary>
		private Panel _panel;
		/// <summary>
		/// This field keeps track of the original value for
		/// the right padding property of the panel.
		/// </summary>
		private int _originalRightPadding = 0;
		/// <summary>
		/// We use this flag to prevent recursion problems.
		/// </summary>
		private bool _adjusting = false;
		/// <summary>
		/// This flag keeps track of the last known state of the scroll bar.
		/// </summary>
		private bool _lastScrollBarVisible = false;
		/// <summary>
		/// We use a timer to check the scroll bar state every so often.
		/// This is necessary since .NET (in another stunning piece of
		/// architecture from Microsoft) provides absolutely no events
		/// attached to the scroll bars of a panel.
		/// </summary>
		private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
		/// <summary>
		/// Construct an AutoScrollFixer and attach it to the provided panel.
		/// Once created, there is no particular reason to keep a reference 
		/// to the AutoScrollFixer in your code.  It will silently do its thing
		/// in the background.
		/// </summary>
		/// <param name="panel"></param>
		public AutoScrollFixer(Panel panel)
		{
			_panel = panel;
			_originalRightPadding = panel.Padding.Right;
			EnableVerticalAutoscroll(_panel);
			_lastScrollBarVisible = _panel.VerticalScroll.Visible;
			_panel.Paint += (s, a) =>
			{
				AdjustForVerticalScrollbar();
			};
			_panel.SizeChanged += (s, a) =>
			{
				//
				//	We can't do something that changes the size while handling
				//	a size change.  So, if an adjustment is needed, we will
				//	schedule it for later.
				//
				if (_lastScrollBarVisible != _panel.VerticalScroll.Visible)
				{
					AdjustLater();
				}
			};
			_timer.Tick += (s, a) =>
			{
				//
				//	Sadly, the combination of the Paint event and the SizeChanged event
				//	is NOT enough to guarantee that we will catch a change in the
				//	scroll bar status.  So, as a last ditch effort, we will check
				//	for a status change every 500 mSecs.  Yup, this is a hack!
				//
				AdjustForVerticalScrollbar();
			};
			_timer.Interval = 500;
			_timer.Start();
		}
		/// <summary>
		/// Enables AutoScroll, but without the Horizontal Scroll bar.
		/// Only the Vertical Scroll bar will become visible when necessary
		/// 
		/// This method is based on this StackOverflow answer ...
		/// https://stackoverflow.com/a/28583501/2175233
		/// </summary>
		/// <param name="panel"></param>
		public static void EnableVerticalAutoscroll( Panel panel )
		{
			panel.AutoScroll = false;
			panel.HorizontalScroll.Enabled = false;
			panel.HorizontalScroll.Visible = false;
			panel.HorizontalScroll.Maximum = 0;
			panel.AutoScroll = true;
		}
		/// <summary>
		/// Queue AdjustForVerticalScrollbar to run on the GUI thread after the current
		/// event has been handled.
		/// </summary>
		private void AdjustLater()
		{
			ThreadPool.QueueUserWorkItem((t) => 
			{
				Thread.Sleep(200);
				_panel.BeginInvoke((Action)(() =>
				{
					AdjustForVerticalScrollbar();
				}));
			});
		}
		/// <summary>
		/// This is where the real work gets done.  When this method is called, we will
		/// simply set the right side padding on the panel to make room for the
		/// scroll bar if it is being displayed, or reset the padding value to 
		/// its original value if not.
		/// </summary>
		private void AdjustForVerticalScrollbar()
		{
			if (!_adjusting)
			{
				try
				{
					_adjusting = true;
					if (_lastScrollBarVisible != _panel.VerticalScroll.Visible)
					{
						_lastScrollBarVisible = _panel.VerticalScroll.Visible;
						Padding p = _panel.Padding;
						p.Right = _lastScrollBarVisible ? _originalRightPadding + System.Windows.Forms.SystemInformation.VerticalScrollBarWidth + 2 : _originalRightPadding;
						_panel.Padding = p;
						_panel.PerformLayout();
					}
				}
				finally
				{
					_adjusting = false;
				}
			}
		}
	}
