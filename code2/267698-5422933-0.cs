            DataTable table = new DataTable();
            // code that populates the table
            DataColumn c = table.Columns.Add("Column1 + Column2", typeof(int));
            int Sum = 0;
            for (int i = 0; i < table.Rows.Count; i++) {
              r = table.Rows[i];
              int col1 = (int)r["Column1"];
              int col2 = (int)r["Column2"];
              int both = col1 + col2;
              Sum += both;
              r[c] = string.Format("{0}", both);
            }
            DataRow summaryRow = table.NewRow();
            summaryRow[c] = (int)((float)Sum / table.Rows.Count + 0.5); // add 0.5 to round
            table.Rows.Add(summaryRow);
