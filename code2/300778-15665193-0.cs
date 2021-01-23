    protected override void Render(HtmlTextWriter writer)
        {
          foreach (GridViewRow r in GridView1.Rows)
          {
            if (r.RowType == DataControlRowType.DataRow)
            {
              r.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
              r.Attributes["onmouseout"] = "this.style.textDecoration='none';";
              r.ToolTip = "Click to select row";
              r.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex,true);
    
            }
          }
    
          base.Render(writer);
        }
