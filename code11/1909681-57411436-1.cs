    double totalamount = 0;
            for (int i = 0; i < lstProductQuantity.Items.Count; i++)
            {
                double itemAmount = 0;
                if(double.TryParse(lstProductQuantity.Items[i], out itemAmount))
                {
                   totalamount += itemAmount;
                }
            }
            textBox2.Text = totalamount.ToString();
