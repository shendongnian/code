    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
       for (int i = 1; i < e.Row.Cells.Count; i++)
           try
           {
              LinkButton lb = (LinkButton)gvData.HeaderRow.Cells[i].Controls[0];
              TextBox tb = (TextBox)e.Row.Cells[i].Controls[0];
    
              if (lb.Text.Contains(Settings.AUTOEXP))
              {
                  tb.TextMode = TextBoxMode.MultiLine;
                  tb.Rows = 7;
              }
              tb.CssClass = "input";
           }
           catch { }
