    List<int> ColumnLengths = new List<int>();
            ds.Tables["TableName"].Columns.Cast<DataColumn>().All((x) => 
            { 
                {
                    ColumnLengths.Add( ds.Tables["TableName"].AsEnumerable().Select(y => y.Field<string>(x).Length).Max());
                } 
                return true; 
            });
            foreach (DataRow row in ds.Tables["TableName"].Rows)
            {
                for(int col=0;col<ds.Tables["TableName"].Columns.Count;col++)
                {
                    SW.Write(row.Field<string>(ds.Tables["TableName"].Columns[col]).PadLeft(ColumnLengths[col] + (4 - (ColumnLengths[col] % 4))));
                }
                SW.WriteLine();
            }
