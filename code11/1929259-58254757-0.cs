    protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView g2 = (GridView)sender;
        g2.EditIndex = e.NewEditIndex;
        GridViewRow gvCustomerRow = g2.NamingContainer as GridViewRow;
        int customerId = (int)gvProducts.DataKeys[gvCustomerRow.RowIndex].Value;
        DataTable dts = new DataTable();
        DateTime dateofBirth = new DateTime();
        sql = @String.Format(" SELECT * FROM `doTable` ");
        sql += String.Format(" WHERE sID IN ('{0}') ", customerId);
        using (OdbcConnection cn =
          new OdbcConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
        {
            using (OdbcCommand cmd =
                new OdbcCommand(sql, cn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection.Open();
                using (OdbcDataAdapter adapt =
                    new OdbcDataAdapter(cmd))
                {
                    adapt.Fill(dts);
                    if (dts.Rows.Count > 0)
                    {
                        g2.DataSource = dts;
                        g2.DataBind();
                        DataRow row = dts.Rows[0];
                        if (String.IsNullOrEmpty(row["DateValuefromDB"].ToString()))
                        {
                            ddlMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                            {
                                MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(a),
                                MonthNumber = a
                            });
                            ddlMonth.DataBind();
                            DropDownList ddlYear = (DropDownList)(g2.Rows[g2.EditIndex].FindControl("ddlYear"));
                            ddlYear.DataSource = Enumerable.Range(DateTime.Now.Year - 0, 12).Reverse();
                            ddlYear.DataBind();
                            ddlYear.Items.Insert(0, new ListItem("0001", "0001"));
                            ddlday.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlMonth.SelectedValue)));
                            ddlday.DataBind();
                            ddlday.SelectedValue = dateofBirth.Day.ToString();
                            ddlMonth.SelectedValue = dateofBirth.Month.ToString();
                            ddlYear.SelectedValue = dateofBirth.Year.ToString();
                        }
                        else
                        {
                            ddlMonth.DataSource = Enumerable.Range(1, 12).Select(a => new
                            {
                                MonthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(a),
                                MonthNumber = a
                            });
                            ddlMonth.DataBind();
                            DropDownList ddlYear = (DropDownList)(g2.Rows[g2.EditIndex].FindControl("ddlYear"));
                            ddlYear.DataSource = Enumerable.Range(DateTime.Now.Year - 0, 12).Reverse();
                            ddlYear.DataBind();
                            ddlYear.Items.Insert(0, new ListItem("0001", "0001"));
                            ddlday.DataSource = Enumerable.Range(1, DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlMonth.SelectedValue)));
                            ddlday.DataBind();
                            ddlday.SelectedValue = Convert.ToDateTime(row["DateValuefromDB"]).Day.ToString();
                            ddlMonth.SelectedValue = Convert.ToDateTime(row["DateValuefromDB"]).Month.ToString();
                            ddlYear.SelectedValue = Convert.ToDateTime(row["DateValuefromDB"]).Year.ToString();
                        }
                    }
                }
            }
        }
    }
