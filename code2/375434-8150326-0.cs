    private void dataGridView1_MouseEnter(object sender, EventArgs e)
    {
    	DataGridView dataGridView = sender as DataGridView;
    	if (dataGridView != null)
    	{
    		dataGridView.ScrollBars = ScrollBars.Both;
    	}
    }
    
    private void dataGridView1_MouseLeave(object sender, EventArgs e)
    {
    	DataGridView dataGridView = sender as DataGridView;
    	if (dataGridView != null)
    	{
    		dataGridView.ScrollBars = ScrollBars.None;
    	}
    }
