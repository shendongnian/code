		    var tbl = new DataTable();
		    int row = -1;
		    int column = -1;
            foreach (DataRow row in tbl.Rows)
            {
                row++;
                if (row == 0)
                {
                    continue;
                }
                foreach (DataColumn col in tbl.Columns)
                {
                    column++;
                    if (column  == 0)
                    {
                        continue;
                    }
                }
            }
