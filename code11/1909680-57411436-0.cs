    double totalamount = 0;
            for (int i = 0; i < lstProductQuantity.Items.Count; i++)
            {
                totalamount += double.Parse(lstProductQuantity.Items[i]);
            }
            textBox2.Text = totalamount.ToString();
