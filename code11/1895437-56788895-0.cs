    if (strFlag == "")
                        {
                            dtStatus = GET_STATUS_FROM_SAPID_FOR_HOTO(dtExcelRows.Rows[i]["Current SAPID"].ToString());
                            if (dtStatus == null && dtStatus.Rows.Count < 0)
                            {
                                ClientScript.RegisterStartupScript(Page.GetType(), "erroralert", "alert('Status cannot be blank for SAP ID entered');", true);
                            }
                            else
                            {
                                dtExcelRows.Rows[i]["UPDATED_STATUS"] = dtStatus.Rows[0][1].ToString();
                                dtExcelRows.AcceptChanges();
                            }
                        }
                    }
                    DataTable dtGetHotoPre = null;
                    var rows = dtExcelRows.AsEnumerable().Where(x => x.Field<string>("UPDATED_STATUS") == "PRE HOTO");
                    if (rows.Any())
                    {
                        dtGetHotoPre = rows.CopyToDataTable();
                    }
                    DataTable dtGetHotoPost = null;
                    var rowsPost = dtExcelRows.AsEnumerable().Where(x => x.Field<string>("UPDATED_STATUS") == "POST HOTO");
                    if (rowsPost.Any())
                    {
                        dtGetHotoPost = rowsPost.CopyToDataTable();
                    }
                    string strFlagStatus = "";
                    if (dtGetHotoPre != null)
                    {
                        if (dtGetHotoPost != null)
                        {
                            strFlagStatus = "No Process";
                        }
                        else
                        {
                            strFlagStatus = "Process";
                            grdDvHoto.DataSource = dtGetHotoPost;
                        }
                    }
                    else
                    {
                        if (dtGetHotoPost != null)
                        {
                            strFlagStatus = "Process";
                            grdDvHoto.DataSource = dtGetHotoPre;
                        }
                        else
                        {
                            strFlagStatus = "No Process";
                        }
                    }
                   // if(dtGetHotoPre != null && dtGetHotoPost != null)
                    if (strFlagStatus == "No Process")
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "erroralert", "alert('The sites contains both Pre and Post Hoto Status, so it cannot be uploaded');", true);
                    }
                    else 
                    {
                        // will move ahead.                        
                        grdDvHoto.DataBind();
                    }
