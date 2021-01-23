      DataSet ds = new DataSet();
            try
            {
                ds = new DataSet();
                if (filterRateDiary.LoadAll())
                {
                    DataView dv = filterRateDiary.DefaultView;
                    DataTable dt = dv.Table;
                    ds.Tables.Add(dt);
                    DataSet ds2 = ds.Clone();
                    ds2.Tables[0].Columns["ExpiryDate"].DataType = Type.GetType("System.DateTime");
                    ds2.Tables[0].Columns["EffectiveDate"].DataType = Type.GetType("System.DateTime");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        ds2.Tables[0].ImportRow(row);
                    }
                    return ds2;
                }
