    public void RemoveRow()
        {
            DataTable dt = new DataTable();
            foreach (var row in dt.Select())
            {
                if (row["ID"].ToString().Equals("NAME"))
                {
                    dt.Rows.Remove(row);
                    dt.AcceptChanges();
                }
            }
        }
