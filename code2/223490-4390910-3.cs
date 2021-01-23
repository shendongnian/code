        cs.Open();
        int remainingStock = 0;
        string Query = "SELECT QTY from tblInventory WHERE ID=19";
        using(SqlCommand cmd = new SqlCommand(Query, cs))
        {
            var result = cmd.ExecuteScaler();
            if (result != null)
            {
                string str = result.ToString();
                if (!string.isNullOrWhiteSpace(str))
                {
                    // NOTE: It would probably be safer to use int.TryParse here
                    remainingStock = Convert.ToInt32(cmd);
                }
  
                if (remainingStock == 0)
                {
                    lbqty.Text = "Not enough stocks.";
                }
                else
                {
                    cmd.CommandText = "UPDATE tblInventory SET QTY = QTY-1 WHERE ID=19";
                    int rowsUpdated = cmd.ExecuteNonQuery();
                    remainingStock--;
                    if (remainingStock == 1)
                    {
                        lbqty.Text = "Re-order. Remaining stocks: 1";
                    }
                    else
                    {
                        string remaining = "Remaining stocks: " + remainingCount.ToString();
                        txtQty.Text = remaining;
                        lbqty.Text = remaining;
                    }
                }
            }
            else
                lbqty.Text = "No stock for contact";
            }
            dgUpdate();
        }
        cs.Close();
