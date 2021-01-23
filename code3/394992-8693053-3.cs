                    SqlCommand command = new SqlCommand("Select SUM(Amount) as sAmount From [Transaction] where AccountID = " + accountid + " AND CurrDate ='" + date+ "' AND TransactionType = '" + transactiontype + "';", connection);
                    connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    while (dr.Read())
                    {
                        totalamount += Convert.ToDecimal(dr.GetString(0));
                        break; // Only read once, since it returns only 1 line.
                    }
                    return totalamount;
