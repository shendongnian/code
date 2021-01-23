    public void errorcheck(int val)
    {
            if (val == 0)
            {
                MessageBox.Show("Enter a number between 1 -20");
            }
    }
    private void nudTwoByTwo_1_ValueChanged(object sender, EventArgs e)
    {
        if (cbTwoBytwo.Checked)
            errorcheck((int)nudTwoByTwo_1.Value);
    }
    private void nudTwoByTwo_2_ValueChanged(object sender, EventArgs e)
    {
        if (cbTwoBytwo.Checked)
            errorcheck((int)nudTwoByTwo_2.Value);  
    }
