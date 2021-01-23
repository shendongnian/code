    protected void Button1_Click(object sender, EventArgs e) {
                Repeater1.DataSource = Enumerable.Range(1, 10);
                Repeater1.DataBind();
                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter(sb);
                HtmlTextWriter writer = new HtmlTextWriter(sw);
                Repeater1.RenderControl(writer);
                Response.Clear();
                Response.AppendHeader("content-disposition", "attachment; filename=foo.xlsx");
                Response.ContentType = "Application/msexcel";
                Response.Write(sb.ToString());
                Response.End();
            }
