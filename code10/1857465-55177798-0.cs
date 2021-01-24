    if (e.Row.RowType == DataControlRowType.DataRow)
    {
        for (int i = 1; i < e.Row.Cells.Count; i++)
        {
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvInventario, "Select$" + e.Row.RowIndex);
            e.Row.ToolTip = "Haga clic para seleccionar esta fila.";
        }
    }
