                if(dt.Rows.Count>0)
                {
                    var count = dt.Rows[0].Table.Columns.Count;
                    for (int i = 0; i < count;i++ )
                    {
                        lsColumns.Add(Convert.ToString(dt.Rows[0][i]));
                    }
}
