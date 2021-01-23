    protected void btnPostback_Click(object sender, System.EventArgs e)
    {
    	for (int i = 0; i <= ListBox1.Items.Count - 1; i++) {
    		ListItem li = ListBox1.Items(i);
    		if (li.Selected) {
    			try {
    				string sValue = li.Text;
    			// Do insert here
    
    			} catch (Exception ex) {
    			}
    		}
    	}
    }
