    using (DataTable dt = new DataTable())
                    {
                        adapter.Fill(dt);
                        DataView dv = new DataView(dt);
                        String strAtual = String.Empty;
                        //Percorrer o DataTable
                        foreach (DataRowView row in dv)
                        {
                            if (strAtual.Equals(row.Row["OrderId"].ToString()))
                            {
                                string strTagNumb = row["TagList"].ToString();
                                CompareDelete(strTagNumb, strAtual, dv);
                                row.Delete();
                                continue;
                            }
                            if (!string.IsNullOrEmpty(row.Row["OrderId"].ToString()))
                                strAtual = row.Row["OrderId"].ToString();
                        }
                        intTotal = dv.Count;
                        gvSchedules.DataSource = dv;
                        gvSchedules.DataBind();
                    }
 
       private void CompareDelete(string strTagNumb, string strAtual, DataView dt)
        {
            foreach (DataRowView row in dt)
            {
                if (row.Row["OrderId"].ToString().Equals(strAtual))
                {
                    row.Row["TagList"] += string.Concat("</br>", strTagNumb);
                    return;
                }
            }
        }
