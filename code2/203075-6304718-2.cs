	public class NoDoubleClickAutoCheckListview : ListView
	{
		private bool checkFromDoubleClick = false;
		protected override void OnItemCheck(ItemCheckEventArgs ice)
		{
			if (this.checkFromDoubleClick)
			{
				ice.NewValue = ice.CurrentValue;
				this.checkFromDoubleClick = false;
			}
			else
				base.OnItemCheck(ice);
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			// Is this a double-click?
			if ((e.Button == MouseButtons.Left) && (e.Clicks > 1)) {
				this.checkFromDoubleClick = true;
			}
			base.OnMouseDown(e);
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			this.checkFromDoubleClick = false;
			base.OnKeyDown(e);
		}
	}
