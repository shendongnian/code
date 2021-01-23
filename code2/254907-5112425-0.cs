		public static List<Control> GetControlsByType(Control ctl, Type type)
		{
			List<Control> controls = new List<Control>();
			foreach (Control childCtl in ctl.Controls)
			{
				if (childCtl.GetType() == type)
				{
					controls.Add(childCtl);
				}
				List<Control> childControls = GetControlsByType(childCtl, type);
				foreach (Control childControl in childControls)
				{
					controls.Add(childControl);
				}
			}
			return controls;
		}
