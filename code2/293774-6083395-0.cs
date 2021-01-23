     private void ComboBox1_SelectedIndexChanged(object sender, 
    		System.EventArgs e)
    {
         if(((ComboBox)sender).SelectedItem == "your value")
                  radioBtn1.IsEnabled = false;
    }
