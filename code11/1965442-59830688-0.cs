            Dictionary<int,int> dictionary=new Dictionary<int, int>();
            DataTable dt=new DataTable();
            dt.Columns.Add("Key", typeof(int));
            dt.Columns.Add("Val", typeof(int));
            foreach (var item in dictionary)
            {
                DataRow dr = dt.NewRow();
                dr["Key"] = item.Key;
                dr["Val"] = item.Value;
                dt.Rows.Add(dr);
            }
