        cs.Open();
        int remainingStock = 0;
        string Query = "SELECT QTY from tblInventory WHERE ID=1";
        using(SqlCommand cmd = new SqlCommand(Query, cs))
        {
            var result = cmd.ExecuteScaler();
            if (result == null)
            {
                 // Handle no result case - this means that there is no item in the database with the ID=1
            }
            string str = result.ToString();
            if (!string.isNullOrWhiteSpace(str))
            {
                // NOTE: It would probably be safer to use int.TryParse here
                remainingStock = Convert.ToInt32(cmd);
            }
          // Unless you are planning to handle the "Not Found" case
          // in a special way, I would remove the code in the else statement
          //else 
          //{
          //    remainingStock = -1; 
          //}
            if (remainingStock == 0)
            {
                lbqty.Text = "Not enough stocks.";
            }
            else
            {
                cmd.CommandText = "UPDATE tblInventory SET QTY = QTY-1 WHERE ID=1";
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
            dgUpdate();
        }
        cs.Close();
