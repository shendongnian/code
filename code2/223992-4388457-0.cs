    private void txtAmount_Leave(object sender, EventArgs e)
    {
        string toParse = txtAmount.Text.TrimStart('$');
        int parsed;
        if (Int32.TryParse(toParse, out parsed))
        {
            double res = (double)parsed / 100;
            txtAmount.Text = "$" + res.ToString();
        }
    }
