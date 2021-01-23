    class MyDataGridView : System.Windows.Forms.DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
        	if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
        		if ((keyData == (Keys.Alt | Keys.S)))
                {
        			//Save data
        		}
        	}
        
        	return base.ProcessCmdKey(msg, keyData);
        }
    }
