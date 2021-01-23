     DataTable dt = new DataTable();
                dt.TableName = "Sort";
                dt.Columns.Add("Check");
                DataRow dr = dt.NewRow();
                dr["Check"] = "12";
                dt.Rows.Add(dr);
    
                DataRow dr2 = dt.NewRow();
                dr2["Check"] = "1283";
                dt.Rows.Add(dr2);
    
                DataRow dr3 = dt.NewRow();
                dr3["Check"] = "store 1283";
                dt.Rows.Add(dr3);
    
                DataRow dr4 = dt.NewRow();
                dr4["Check"] = "23";
                dt.Rows.Add(dr4);
    
                DataView dv = new DataView();
                dv.Table = dt;
    
                AlphanumComparator<string> comparer = new AlphanumComparator<string>();
                //DataTable dtNew = dv.Table;
                DataTable dtNew = dv.Table.AsEnumerable().OrderBy(x => x.Field<string>("Check"), comparer).CopyToDataTable();
                dtNew.TableName = "NaturalSort";
    
                dv.Table = dtNew;
