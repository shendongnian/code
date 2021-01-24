        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            bool found = false;
            foreach (DataRow dr2 in ds1.Tables[0].Rows)
            {
                string table2 = dr2["code"].ToString();
                if (i.ToString() == table2.ToString())
                {
                    found = true;
                }
            }
            if(!found) dsnew.Tables[0].Rows.Add(i);
        }
