    private void B_Click(object sender, EventArgs e) {
      var thsBtn = sender as Button; 
    
      // you may want to add a condition into FirstOrDefault(), e.g. 
      //   .FirstOrDefault(lbl => lbl.Text == "_") 
      // - first label with "_" Text
      Label lblToProcess = m_CreatedLabels
        .FirstOrDefault(); 
    
      if (null != lblToProcess) 
        lblToProcess.Text = thsBtn.Text; 
    
      thsBtn.Enabled = false; 
    }
