    private void ComboBox1_SelectedIndexChanged(object sender, 
		System.EventArgs e)
	{
		ComboBox comboBox = (ComboBox) sender;
		
		string myItemText = (string) ComboBox1.SelectedItem;
        // populate
        MyTextBox.Text = myItemText;
    }
