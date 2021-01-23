        Table table = new Table();
        table.GridLines = GridView1.GridLines;
        table.Rows.Add(GridView1.HeaderRow);
        foreach (GridViewRow gvr in GridView1.Rows)
        {
            table.Rows.Add(gvr);
            
        }
        for (int iRows = 0; iRows < table.Rows.Count; iRows++)
        {
            for (int iCells = 0; iCells < table.Rows[iRows].Cells.Count; iCells++)
            {
                //code here
            }
        }
