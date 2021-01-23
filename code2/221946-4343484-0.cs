                int ID = Convert.ToInt32(GridView1.SelectedDataKey.Value);
                try
                {
                    CrystalDecisions.CrystalReports.Engine.ReportDocument rpt =
                                new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                    string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                    string[] str = conn.Split(';');
                    string server = str[0].Substring(str[0].IndexOf(" = ") + 3);
                    string database = str[1].Substring(str[1].IndexOf(" = ") + 3);
                    string userid = str[2].Substring(str[2].IndexOf(" = ") + 3);
                    string password = str[3].Substring(str[3].IndexOf(" = ") + 3);
                    rpt.Load(Server.MapPath("~/Engineering/Reports/Report.rpt"));
                    for (int i = 0; i < rpt.DataSourceConnections.Count; i++)
                        rpt.DataSourceConnections[i].SetConnection(server, database, userid, password);
                    rpt.SetParameterValue(0, ID);
                    rpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, HttpContext.Current.Response, true, "Report");
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
