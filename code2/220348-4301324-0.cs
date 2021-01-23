	public partial class FrmMain : Form {
		Point mouse_offset;
		
		private void FrmMain_MouseDown(object sender, MouseEventArgs e) {
			mouse_offset = new Point(-e.X, -e.Y);
		}
		private void FrmMain_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				Point mousePos = Control.MousePosition;
				mousePos.Offset(0, mouse_offset.Y);
				mousePos.X = this.Location.X;
				this.Location = mousePos;
			}
		}
	}
