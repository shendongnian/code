    private void B_Click(object sender, EventArgs e) {
      var thsBtn = sender as Button; 
    
      Label lbl = m_CreatedLabels
        .FirstOrDefault(); // you may want to add a condition here
    
      if (null != lbl) 
        lbl.Text = thsBtn.Text; 
    
      thsBtn.Enabled = false; 
    }
