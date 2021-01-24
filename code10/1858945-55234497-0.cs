            // assumption is that both dt1 and dt2 has same number of rows
            // otherise while accessing dt2 we can get index out of range exception
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                DataRow dr1 = dt1.Rows[i];
                DataRow dr2 = dt2.Rows[i];
                // accessing the column below would return a system.object variable,
                // need to convert it to the right type using one of the convert calls, e.g. Convert.ToInt16(dr1["ColumnName"])
                if (dr1["ColumnName"] == dr2["ColumnName"])
                {
                    // do whatever you want to do here
                }
            }
