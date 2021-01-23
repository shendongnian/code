    protected void gvData_PreRender(object sender, EventArgs e)
    {
        if (this.gvData.EditIndex != -1)
        {
            TextBox tb = new TextBox();
            
            for (int i = 0; i < gvData.Rows[gvData.EditIndex].Cells.Count; i++)
                try
                {
                    tb = (TextBox)
                        gvData.Rows[gvData.EditIndex].Cells[i].Controls[0];
                    if (tb.Text.Length >= 30)
                    {
                        tb.TextMode = TextBoxMode.MultiLine;
                    }
                }
                catch { }
        }
    }
