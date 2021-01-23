            DataTable dt = new DataTable("MyTable");
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (row[column] != null)
                    {
                        string value = row[column].ToString();
                        if (!String.IsNullOrEmpty(value))
                        {
                            // Do something
                        }
                    }
                }
            }
