            try
            {
                decimal qty= 0;
                decimal price = 0;
                decimal tax = 0;
                decimal Total = 0;
                for (int i = 0; i < drGrdView1.Rows.Count; i++)
                {
                    if (drGrdView1.Rows[i].Cells[7].Value.ToString() == blcnt.ToString())
                    {
                        qty += Convert.ToDecimal(drGrdView1.Rows[i].Cells[3].Value);
                        price += Convert.ToDecimal(drGrdView1.Rows[i].Cells[4].Value);
                        tax += Convert.ToDecimal(drGrdView1.Rows[i].Cells[5].Value);
                        Total += Convert.ToDecimal(drGrdView1.Rows[i].Cells[6].Value);
                      
                     }
                }
                lblGTax.Text = tax.ToString();
                lblGQty.Text = qty.ToString();
                lblGPrice.Text = price.ToString();
                lblGTot.Text = Total.ToString();
            }
            catch
            {
            }
        }
