    class MyDataGridView : System.Windows.Forms.DataGridView
    {
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
        {
 
            MessageBox.Show("Key Press Detected");
        	if ((keyData == (Keys.Alt | Keys.S)))
            {
                //Save data
        	}
        
        	return base.ProcessCmdKey(ref msg, keyData);
        }
    }
