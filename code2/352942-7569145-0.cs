    protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            AddRowSelectToGridView(gridView);
            base.Render(writer);
        }
        private void AddRowSelectToGridView(GridView gv)
        {
            try
            {
                foreach (GridViewRow row in gv.Rows)
                {
                    row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                    row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + row.RowIndex.ToString(), true));
                }
            }
            catch (Exception ex)
            {
            }
        }
