    for (int i = 1; i <= FirstSplit.Length-1; i++)
            {
                string[] cols = FirstSplit[i].Split(':');
                //Now write it out back to SSIS for loading
                Output1Buffer.AddRow();
                Output1Buffer.Product = Product;
                Output1Buffer.Action = Action;
                Output1Buffer.ColumnName = cols[0];
                Output1Buffer.ColumnValue = cols[1];
            }
