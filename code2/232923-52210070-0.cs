    DataTable dt = new DataTable();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Column_Name"] == DBNull.Value)
                {
                    //Do something
                }
                else
                {
                    //Do something
                }
            }
