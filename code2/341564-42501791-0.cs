      System.Data.DataSet ds = db.MySelect(
                        "Fields",
                        "Table",
                         "Condition"
                         );
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                   object value=Tables[0].Rows[indx]["field name"];
                }
            }
