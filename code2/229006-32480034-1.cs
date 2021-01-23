    protected override void WndProc(ref Message m) {
		const UInt32 WM_NCACTIVATE = 0x0086;
		if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0) {
			handleDeactivate();
		} else {
			base.WndProc(ref m);
       }
	}
