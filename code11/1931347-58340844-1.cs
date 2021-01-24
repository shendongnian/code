    private void txtBtn1_Click(object sender, EventArgs e)
    {
        if (double.TryParse(txtBox1.Text, out double a) && 
            double.TryParse(txtBox2.Text, out double b))
          txtLbl.Text = (a + b).ToString(); // if both TextBoxes have valid values
        else { 
          // At least one TextBox has invalid Text
          txtLbl.Text = "???";  
        } 
    }
