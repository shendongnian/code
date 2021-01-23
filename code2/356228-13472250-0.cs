    protected override void DefWndProc(ref System.Windows.Forms.Message m)
	{
		if (!(m.Msg == 8))
			base.DefWndProc(m);
 }    
