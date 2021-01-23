    .
    .
    .
       string msgBoxTxt = "";
    
        if (this.txtQuantity.Text != "0")
        {
            quantityNum = double.Parse(this.txtQuantity.Text);
            quantityPrice = cost * quantityNum;
            this.lblFinalCost.Text = "Cost: " + quantityPrice.ToString("c");
        }
        else
            msgBoxTxt += "Please enter a quantity! ";
    
       if (this.cmboBoxJuiceFlav.Text != "Select a flavor")
           this.lblFinalFlavor.Text = "Flavor: " + this.cmboBoxJuiceFlav.Text;
       else
           msgBoxTxt += "Please select a flavor!";
    
       if (msgBoxTxt != "")
            MessageBox.Show(msgBoxTxt);
