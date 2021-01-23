    		private KeyboardHookListener k_keyListener;
    
    		private void ThisWorkbook_Startup(object sender, System.EventArgs e)
    		{
    			k_keyListener = new KeyboardHookListener(new AppHooker());
    			k_keyListener.Enabled = true;
    			k_keyListener.KeyDown += new KeyEventHandler(k_keyListener_KeyDown);
    		}
    
    		void k_keyListener_KeyDown(object sender, KeyEventArgs e)
    		{
    			if (Control.ModifierKeys == Keys.Control)
    				if (e.KeyCode == Keys.V)
    				{
    					Worksheet actSht = ActiveSheet as Worksheet;
    					Range rng = actSht.Application.Selection as Range;
    					if (MessageBox.Show("You are about to paste values only. Do you want to continue?", "Paste Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
    					{
    						rng.PasteSpecial(XlPasteType.xlPasteValues, XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
    					}
    					e.Handled = true;
    				}
    		}
