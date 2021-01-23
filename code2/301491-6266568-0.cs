        conn.Open();
        // MOVE THESE
        /**
        TableRow r = new TableRow();
        TableCell c = new TableCell();
        **/
        SqlDataReader reader = comm.ExecuteReader();
          while (reader.Read())
        {
              // TO HERE..  so that a new row and cell are created for each record in your reader
              TableRow r = new TableRow();
              TableCell c = new TableCell();
              c.Controls.Add(new LiteralControl(reader["Name"].ToString()));
                r.Cells.Add(c);
                //Table1.Rows.Add(r);   -- ADD THE ROW AFTER THE SECOND FIELD... THEN YOU HAVE 2 COLUMNS
                c.Controls.Add(new LiteralControl(reader["RollID"].ToString()));
                c = new TableCell(); // CREATE A NEW CELL, FOR A NEW COLUMN
                r.Cells.Add(c);
                Table1.Rows.Add(r);
        }
