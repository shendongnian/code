    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
            {
                bool found = false;
                bool asterisk = false;
                foreach (DataRow dr2 in ds1.Tables[0].Rows)
                {
                    string table2 = dr2["code"].ToString();
                    string deletedVchr = dr2["type"].ToString();
                    if (i.ToString() == table2.ToString() && deletedVchr == "0")
                    {
                      found = true;
                    }
                    else if (i.ToString() == table2.ToString() && deletedVchr == "1")
                    {
                      asterisk = true;
                    }
                 }
                 if (!found && !asterisk)
                    dsnew.Tables[0].Rows.Add(i); 
                 if(asterisk)
                    dsnew.Tables[0].Rows.Add(i+"*");        
              }
