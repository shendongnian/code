        decimal rite = 0m;
        decimal left = 0m;
        try
        {
            rite = Convert.ToDecimal(textBox1.Text);
            left = Convert.ToDecimal(textBox2.Text);
        }
        catch (Exception)
        {
            string swr = "Please enter REAL a number, can be with decimals";
            label2.Text = swr;
        }
