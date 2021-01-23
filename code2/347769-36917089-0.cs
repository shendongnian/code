	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.ComponentModel.Design;
	using System.Drawing;
	using System.Windows.Forms;
	namespace ControlTest
	{
	  public sealed class InvisibleControl : Control
	  {
		public InvisibleControl()
		{
		  TabStop = false;
		}
		#region public interface
		// Reduce the temptation ...
		public new AnchorStyles Anchor
		{
		  get { return base.Anchor; }
		  set { base.Anchor = AnchorStyles.None; }
		}
		public new DockStyle Dock
		{
		  get { return base.Dock; }
		  set { base.Dock = DockStyle.None; }
		}
		// We don't ever want to move away from (0,0)
		public new Point Location
		{
		  get { return base.Location; }
		  set { base.Location = Point.Empty; }
		}
		// Horizontal or vertical orientation?
		private Orientation _orientation = Orientation.Horizontal;
		[DefaultValue(typeof(Orientation), "Horizontal")]
		public Orientation Orientation
		{
		  get { return _orientation; }
		  set
		  {
			if (_orientation == value) return;
			_orientation = value;
			ChangeSize();
		  }
		}
		#endregion
		#region overrides of default behaviour
		// We don't want any margin around us
		protected override Padding DefaultMargin => Padding.Empty;
		// Clean up parent references
		protected override void Dispose(bool disposing)
		{
		  if (disposing)
			SetParent(null);
		  base.Dispose(disposing);
		}
		// This seems to be needed for IDE support, as OnParentChanged does not seem
		// to fire if the control is dropped onto a surface for the first time
		protected override void OnHandleCreated(EventArgs e)
		{
		  base.OnHandleCreated(e);
		  ChangeSize();
		}
		// Make sure we don't inadvertantly paint anything
		protected override void OnPaint(PaintEventArgs e) { }
		protected override void OnPaintBackground(PaintEventArgs pevent) { }
		// If the parent changes, we need to:
		// A) Unsubscribe from the previous parent's Resize event, if applicable
		// B) Subscribe to the new parent's Resize event
		// C) Resize our control according to the new parent dimensions
		protected override void OnParentChanged(EventArgs e)
		{
		  base.OnParentChanged(e);
		  // Perform A+B
		  SetParent(Parent);
		  // Perform C
		  ChangeSize();
		}
		// We don't really want to be resized, so deal with it
		protected override void OnResize(EventArgs e)
		{
		  base.OnResize(e);
		  ChangeSize();
		}
		#endregion
		#region private stuff
		// Make this a default handler signature with optional params, so that this can
		// directly subscribe to the parent resize event, but also be called without parameters
		private void ChangeSize(object sender = null, EventArgs e = null)
		{
		  Rectangle client = Parent?.ClientRectangle ?? new Rectangle(0, 0, 10, 10);
		  Size proposedSize = _orientation == Orientation.Horizontal
			? new Size(client.Width, 0)
			: new Size(0, client.Height);
		  if (!Size.Equals(proposedSize)) Size = proposedSize;
		}
		// Handles reparenting
		private Control boundParent;
		private void SetParent(Control parent)
		{
		  if (boundParent != null)
			boundParent.Resize -= ChangeSize;
		  boundParent = parent;
		  if (boundParent != null)
			boundParent.Resize += ChangeSize;
		}
		#endregion
	  }
	}
