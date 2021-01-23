    StringBuilder sb = new StringBuilder();          
            foreach (DataColumn col in dt.Columns)
            {
                if (col.ColumnName.Contains(","))
                {
                    sb.Append(String.Format("\"{0}\",", col.ColumnName));
                }
                else
                {
                    sb.Append(String.Format("{0},", col.ColumnName));
                }
            }
