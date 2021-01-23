    private void cbtns_ClickButtonArea(System.Object Sender, System.Windows.Forms.MouseEventArgs e)
    {
    	CButtonLib.CButton[] cbtn = {
    		cbtn_a,
    		cbtn_b,
    		cbtn_c,
    		cbtn_d
    	};
    	CButtonLib.CButton clickedBtn = (CButtonLib.CButton)sender;
    
    	foreach (CButtonLib.CButton cb in cbtn) {
    		if (cb == clickedBtn)) {
    			cb.Enabled = false;
    		} else {
    			cb.Enabled = true;
    		}
    	}
    }
