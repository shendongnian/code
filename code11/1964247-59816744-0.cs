    float gridHeight = 20.0f;
    for (int i = 0; i < grid.Rows.Count; i++)
    {
       grid.Rows[i].Height = gridHeight;
       grid.Rows[i].Cells[0].Style.Borders.Right = new PdfPen(PdfBrushes.DarkRed);
       grid.Rows[i].Cells[1].Style.Borders.Left = new PdfPen(PdfBrushes.DarkRed); 
    }
