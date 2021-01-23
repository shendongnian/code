    private void txtPercent_TextChanged(object sender, EventArgs e)
    {
        if (sender == txtMyPercent)
        {
            txtYourPercent.Text = (100 - int.Parse(txtMyPercent.Text)).ToString();
        }
        else if (sender == txtYourPercent)
        {
            txtMyPercent.Text = (100 - int.Parse(txtYourPercent.Text)).ToString();
        }
    }
