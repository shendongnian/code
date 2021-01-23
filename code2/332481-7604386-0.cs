	public class GlassControlRenderer : NativeWindow
	{
		private Control Control;
		private Bitmap Bitmap;
		private Graphics ControlGraphics;
		private object Lock = new object();
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case 0x14: // WM_ERASEBKGND
					this.CustomPaint();
					break;
				case 0x0F: // WM_PAINT
				case 0x85: // WM_NCPAINT
				case 0x100: // WM_KEYDOWN
				case 0x101: // WM_KEYUP
				case 0x102: // WM_CHAR
				case 0x200: // WM_MOUSEMOVE
				case 0x2A1: // WM_MOUSEHOVER
				case 0x201: // WM_LBUTTONDOWN
				case 0x202: // WM_LBUTTONUP
				case 0x285: // WM_IME_SELECT
				case 0x300: // WM_CUT
				case 0x301: // WM_COPY
				case 0x302: // WM_PASTE
				case 0x303: // WM_CLEAR
				case 0x304: // WM_UNDO
					base.WndProc(ref m);
					this.CustomPaint();
					break;
				default:
					base.WndProc(ref m);
					break;
			}
		}
		private Point Offset { get; set; }
		public GlassControlRenderer(Control control, int xOffset, int yOffset)
		{
			this.Offset = new Point(xOffset, yOffset);
			this.Control = control;
			this.Bitmap = new Bitmap(this.Control.Width, this.Control.Height);
			this.ControlGraphics = Graphics.FromHwnd(this.Control.Handle);
			this.AssignHandle(this.Control.Handle);
		}
		public void CustomPaint()
		{
			this.Control.DrawToBitmap(this.Bitmap, new Rectangle(0, 0, this.Control.Width, this.Control.Height));
			this.ControlGraphics.DrawImageUnscaled(this.Bitmap, this.Offset); // -1, -1 for content controls (e.g. TextBox, ListBox)
		}
	}
