	private void txtOctet1_TextChanged(object sender, EventArgs e)
	{
		double numCheck1;
		TextBox txtToValidate = txtOctet1; // Variable 1
		Label lblError = lblOctet1Error; // Variable 2
		
    /* Select from here in the next step */ 
		if (txtToValidate.Text == "") // Here, txtOctet1 replaced
		{
		}
		else
		{
			numCheck1 = Convert.ToDouble(txtToValidate.Text); // Here, txtOctet1 replaced
			if (numCheck1 < 0 | numCheck1 > 255)
			{
				btnSubnetting.Enabled = false;
				lblError.Text = "Error"; // Here, lblOctet1Error replaced
				lblError.BackColor = Color.Red; // Here, lblOctet1Error replaced
				lblError.ForeColor = Color.White; // Here, lblOctet1Error replaced
			}
			else
			{
				btnSubnetting.Enabled = true;
				lblError.Text = "No Error"; // Here, lblOctet1Error replaced
				lblError.BackColor = Color.White; // Here, lblOctet1Error replaced
				lblError.ForeColor = Color.Black; // Here, lblOctet1Error replaced
			}
		}
    /* Select to here in the next step */ 
	}
