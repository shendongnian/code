    private void btnEquals_Click(object sender, EventArgs e)
    {
        if (plusButtonClicked == true)
        {
            total2 = total1 + double.Parse(txtDisplay.Text);
        }
        else if (minusButtonClicked == true);  // <<== There should not be a semicolon here
        {
            total2 = total1 - double.Parse(txtDisplay.Text);
        }
        else if (multiplyButtonClicked == true); // <<== or here
        {
            total2 = total1 * double.Parse(txtDisplay.Text);
        }
        else
        {
            total2 = total1 / double.Parse(txtDisplay.Text);
        }
