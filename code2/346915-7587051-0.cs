    private void dataGridView1_DoubleClick(object sender, EventArgs e)
    {
    	Control newControl = new MyTextBox();
    	dataGridView1.Controls.Add(newControl);
    	dataGridView1.ClearSelection();  //to be sure that any of cells are selected  
    	newControl.Focus();
    }
    class MyTextBox : TextBox
    {
    	protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    	{
    		if (keyData == Keys.Enter || keyData == Keys.Tab || keyData == Keys.A)
    		{
    			Trace.WriteLine("Ok, key = " + keyData);
    			return true;///Or false??? return to override the basic behavior
    		} 
    		return base.ProcessCmdKey(ref msg, keyData);
    	}
     }
