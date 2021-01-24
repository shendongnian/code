    private void txtBtn1_Click(object sender, EventArgs e) {
        if (double.TryParse(txtBox1.Text, out double a)) {
            if (double.TryParse(txtBox2.Text, out double b))   
                txtLbl.Text = (a + b).ToString(); 
            else {
                if (txtBox2.CanFocus)
                    txtBox2.Focus();
                MessageBox("Mot a Valid 'B' Number");
            }
        } 
        else {
            if (txtBox1.CanFocus)
                txtBox1.Focus();
            MessageBox("Mot a Valid 'A' Number");
        }
    }
