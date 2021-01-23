    DataTable dt = GeneralFunctions.ToDataTable(HereputyourlistforcovertToDataTable);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            Response.Clear();
                            Response.ClearHeaders();
                            Response.ClearContent();
                            Response.ContentType = "text/CSV";
                            Response.AddHeader("content-disposition", "attachment; filename=ReceivingLog.csv");
                            Response.Write(ToCSV(dt));
                            Response.End();
                        }
                    }
