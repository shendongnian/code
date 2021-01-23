    private void SubmitComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
    	switch (this.submitComboBox.SelectedItem.ToString())
    	{
    		case "E-Mail":
    			this.Controls.Add(new Web.Mail());
    			break;
    		case "FTP":
    			this.Controls.Add(new Web.Ftp());
    			break;
    		case "HTTP":
    			this.Controls.Add(new Web.Http());
    			break;
    	}
    }
