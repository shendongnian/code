                DataTable dt = new DataTable();
                int sum = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    foreach (DataColumn dc in dt.Columns)
                    {
                        sum += (int)dr[dc];
                    }
                } 
