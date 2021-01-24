     protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                
               ShowWindow(SelectedWindow, SW_MAXIMIZE);
		       //SendKeys.Send("^(v)");
			   SendKeys.SendWait("^(v)");
			   
               ShowWindow(SelectedWindow, SW_MINIMIZE);
			   
                
            }
        }
