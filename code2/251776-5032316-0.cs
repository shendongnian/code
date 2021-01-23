		    var tbl = new DataTable();
		    int row = 0;
		    int column = 0;
            foreach (DataRow row in tbl.Rows)
            {
                if (row == 0)
                {
                    continue;
                }
                foreach (DataColumn col in tbl.Columns)
                {
                    if (column  == 0)
                    {
                        continue;
                    }
                    column++;
                }
                row++;
            }
