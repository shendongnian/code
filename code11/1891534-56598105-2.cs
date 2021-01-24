       protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string fieldType = e.Row.Cells[2].Text;
                    TextBox txtData = e.Row.Cells[3].FindControl("TextBox1") as TextBox;
                    switch (fieldType)
                    {
                        case "Date":
                        case "TextBox":
                            txtData.EnableViewState = false;
                            txtData.CssClass = "form-control";
                            break;
                        case "TextArea":
                            txtData.EnableViewState = false;
                            txtData.CssClass = "form-control";
                            txtData.TextMode = TextBoxMode.MultiLine;
                            txtData.Rows = 5;
                            txtData.Columns = 50;
                            break;
                        case "Content":
                            txtData.TextMode = TextBoxMode.MultiLine;
                            txtData.EnableViewState = false;
                            txtData.Columns = 10;
                            txtData.MaxLength = 150;
                            txtData.Height = 200;
                            txtData.CssClass = "Content-container";
                            break;
                    }
                }
            }
            protected void btnSave_Click(object sender, EventArgs e)
            {
                SaveTemplateDetails();
            }
            private void SaveTemplateDetails()
            {
                foreach (GridViewRow row in gv.Rows)
                {
                    foreach (Control c in row.Cells[3].Controls)
                    {
                        TextBox txtDate = c as TextBox;
                        if (txtDate != null)
                        {
                            string data = txtDate.Text;
                        }
                    }
                }
            }
