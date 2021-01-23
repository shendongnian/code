    private void btnCalculate_Click(object sender, EventArgs e)
    {
    double quan = 0, item = 28;
    foreach (RadioButton temp in gbQuan.Controls)
    {
        if (temp.Checked)
            quan = Convert.ToDouble(temp.Text);
    }
    lblTotal.Text = "The total cost is: £" + (item * quan).ToString("0.00");
    }
