    	protected override void WndProc(ref System.Windows.Forms.Message m)
	{
		//WM_MOUSEACTIVATE = 0x21
		if (m.Msg == 0x21 && this.CanFocus && !this.Focused)
			this.Focus();
		base.WndProc(m);
	}
