    DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();
                dt1 = dt.Copy();
                for (int i = 5; i < 65; i++)
                {
                    dt1.Columns.RemoveAt(i);   
                }
