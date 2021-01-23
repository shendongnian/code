 	public class LayerWindow : Form
	{
		public LayerWindow()
		{
			FormBorderStyle = FormBorderStyle.None;
			StartPosition = FormStartPosition.Manual;
			TransparencyKey = Color.Fuchsia;
			base.BackColor = Color.Black;
			Opacity = 0.50;
			ShowInTaskbar = false;
		}
		public void Show(Control parent)
		{
			if (parent == null)
				throw new ApplicationException("No parent provided");
			var container = parent.FindForm();
			if (container == null)
				throw new ApplicationException("No parent Form found. Make sure that the control is contained in a form before showing a popup.");
			Location = PointToScreen(container.Location);
			Bounds = container.Bounds;
			Owner = container;
			Owner.Enabled = false;
			base.Show(container);
		}
		public void Unmask()
		{
			if (Owner != null)
				Owner.Enabled = true;
			Hide();
		}
