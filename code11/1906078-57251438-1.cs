    private void btnBack_Click(object sender, EventArgs e)
    {
      if (tabControl1.SelectedIndex > 0)
    	tabControl1.SelectedIndex--;
    }
    
    private void btnNext_Click(object sender, EventArgs e)
    {
      if(tabControl1.SelectedIndex < tabControl1.TabPages.Count)
    	tabControl1.SelectedIndex++;
    }
