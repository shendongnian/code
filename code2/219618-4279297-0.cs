        private void UpdateInternalControls(Control parent)
		{
			UpdateControl(parent, delegate(Control control)
			                      	{
			                      		control.BackColor = Color.Turquoise;
			                      		control.ForeColor = Color.Yellow;
			                      	});
		}
		private static void UpdateControl(Control c, Action<Control> action)
		{
			action(c);
			foreach (Control child in c.Controls)
			{
				UpdateControl(child, action);
			}
		}
