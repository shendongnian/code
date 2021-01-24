            DataTable dtFull = GetData();
            DataTable newDt = new DataTable();
            newDt.Columns.Add("ID", typeof(String));
            newDt.Columns.Add("Name", typeof(String));
            newDt.Columns.Add("ID", typeof(String));
            newDt.Columns.Add("Name", typeof(String));
            bool exit = true;
            int pagecount = 10;
            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;
            while (exit)
            {
               
                for (j = 0; (j<pagecount);j++)
                {
                    DataRow newrow = newDt.NewRow();
                    newrow["ID"] = dtFull.Rows[i][0].ToString();
                    newrow["Name"] = dtFull.Rows[i][1].ToString();
                    newDt.Rows.Add(newrow);
                    
                    i++;
                    m++;
                    if (i >= dtFull.Rows.Count)
                    {
                        exit = false;
                        break;
                    }
                }
                if (exit)
                {
                    k = m - pagecount;
                    for (j = 0; (j < pagecount); j++)
                    {
                        newDt.Rows[m - pagecount + j][2] = dtFull.Rows[i][0].ToString();
                        newDt.Rows[m - pagecount + j][3] = dtFull.Rows[i][1].ToString();
                        i++;
                        if (i >= dtFull.Rows.Count)
                        {
                            exit = false;
                            break;
                        }
                    }
                }      
                
                
            }
