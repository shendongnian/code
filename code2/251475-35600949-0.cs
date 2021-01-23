                    ListBox ddl_Makeid = (ListBox)e.Row.FindControl("lst_hopid");
                    DataSet ds = new DataSet();
                    con.Open();
                    string cmdstr = "SELECT HeadsOfPricingId,HeadsOfPricing FROM tblHeadsOfPricing";
                    SqlCommand cmd = new SqlCommand(cmdstr, con);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(ds);
                    ddl_Makeid.DataSource = ds.Tables[0];
                    ddl_Makeid.DataTextField = "HeadsOfPricing";
                    ddl_Makeid.DataValueField = "HeadsOfPricingId";
                    DataRowView drv = e.Row.DataItem as DataRowView;
                    ddl_Makeid.DataBind();
                    con.Close();
                    Label lbl_texbox = (Label)e.Row.FindControl("lbl_hopId_edit");
                    string stsplit = lbl_texbox.Text;
                    char[] splichar = { ',' };
                    string[] strarray = stsplit.Split(splichar);
                    //ListBox listbox = (ListBox)e.Row.FindControl("lst_hopid");
                    ListBox listboxtest = new ListBox();
                    for (int x = 0; x < strarray.Length; x++)
                    {
                        if (strarray[x] != null && strarray[x] !="")
                        {
                            //ddl_Makeid.SelectedValue += strarray[x];
                            ddl_Makeid.Items.FindByValue(strarray[x]).Selected = true;
                            //listboxtest = (ListBox)e.Row.Cells[x].FindControl("Lst_New_hopid");
                        }
                    }
                    
                
                }}
