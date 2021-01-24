	public void EnumerateChildren(Control root)
	{
		foreach (Control control in root.Controls)
		{
			if (control.IsHandleCreated)
			{
				//Handle is already created
			}
			else
			{
				control.CreateControl();
				if (control.IsHandleCreated == false)
				{
					//The access the handle directly
					MethodInfo ch = control.GetType().GetMethod("CreateHandle", BindingFlags.NonPublic | BindingFlags.Instance);
					Invoke((System.Windows.Forms.MethodInvoker)delegate { ch.Invoke(control, new object[0]); });
				}
			}
			if (control.Controls != null)
			{
				EnumerateChildren(control);
			}
		}
	}
