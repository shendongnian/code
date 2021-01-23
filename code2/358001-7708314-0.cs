	if (this.cmboBoxJuiceFlav.Text != "Select a flavor")
	{
		this.lblFinalFlavor.Text = "Flavor: " + this.cmboBoxJuiceFlav.Text;
		if (this.txtQuantity.Text != "0")
		{
			quantityNum = double.Parse(this.txtQuantity.Text);
			quantityPrice = cost * quantityNum;
			this.lblFinalCost.Text = "Cost: " + quantityPrice.ToString("c");
		}
		else
		{
			MessageBox.Show("Please enter a quantity!");
		}
	}
	else
	{
		MessageBox.Show("Please select a flavor!");
	}
