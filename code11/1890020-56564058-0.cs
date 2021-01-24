            DataTable dtFull = GetData();
            DataTable newDt = new DataTable();
            newDt.Columns.Add("ID", typeof(String));
            newDt.Columns.Add("Name", typeof(String));
            newDt.Columns.Add("ID", typeof(String));
            newDt.Columns.Add("Name", typeof(String));
            for (int i = 0; i < dtFull.Rows.Count; i++)
            {
                DataRow newrow = newDt.NewRow();
                if (i * 2  < dtFull.Rows.Count)
                {
                    newrow["ID"] = dtFull.Rows[i * 2][0].ToString();
                    newrow["Name"] = dtFull.Rows[i * 2][1].ToString();
                    newDt.Rows.Add(newrow);
                }
                
                if (i*2+1 < dtFull.Rows.Count)
                {
                    newDt.Rows[i][2] = dtFull.Rows[i * 2 + 1][0].ToString();
                    newDt.Rows[i][3] = dtFull.Rows[i * 2 + 1][1].ToString();
                }
                
            }
