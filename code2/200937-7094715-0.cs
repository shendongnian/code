	/// <summary>
	/// Overrides the control's class style parameters.
	/// </summary>
	protected override CreateParams CreateParams
	{
		get
		{
		Int32 CS_VREDRAW = 0x1;
		Int32 CS_HREDRAW = 0x2;
		Int32 CS_OWNDC = 0x20;
		CreateParams cp = base.CreateParams;
		cp.ClassStyle = cp.ClassStyle | CS_VREDRAW | CS_HREDRAW | CS_OWNDC | ...;
		return cp;
		}
	}
