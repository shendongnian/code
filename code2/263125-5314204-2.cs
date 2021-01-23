        private static void PopulateReport(Table table, string connection)
        {
            table.Rows.Clear();
            PopulateReportRow(table, "Amount", "Total");            
            string commandText = @"...";
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand(commandText, conn))
                {
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        double total = 0d;
                        while (reader.Read())
                        {
                            double amount = (double)reader["amount"];
                            total += amount;
                            PopulateReportRow(table, amount.ToString("N"), total.ToString("N"));
                        }
                    }
                }
            }
        }
        private static void PopulateReportRow(Table table, string amountValue, string totalValue)
        {
            const int cellBorderWidth = 2;
            int rowIndex = table.Rows.Add(new TableRow());
            TableCell amountCell = new TableCell();
            table.Rows[rowIndex].Cells.Add(amountCell);
            amountCell.BorderWidth = cellBorderWidth;
            amountCell.Text = amountValue;
            TableCell totalCell = new TableCell();
            table.Rows[rowIndex].Cells.Add(totalCell);
            totalCell.BorderWidth = cellBorderWidth;
            totalCell.Text = totalValue;
        }
