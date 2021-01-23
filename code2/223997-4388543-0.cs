    private void txtAmount_Leave(object sender, EventArgs e)
    {
       int x = 0;
       int x = int.TryParse(txtAmount.Text.Replace("$", string.Empty), out x);
       double res = (double)x / 100;
       txtAmount.Text = "$" + res.ToString();
    }
