    private static Table DibujarSelloYFirma(Section sec)
    {
        Table table = new Table();
        Column column = table.AddColumn(Unit.FromCentimeter(3));
        Row row = table.AddRow();
        Cell cell = row.Cells[0];
        cell.AddParagraph("SEAL COMMERCE");
        cell.Format.Alignment = ParagraphAlignment.Center;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.Format.Font.Bold = true;
        cell.Format.Font.Size = 3;
        cell.Format.Font.Name = "Verdana";
        cell.Format.Font.Italic = true;
        cell.Borders.Right.Width = 0.5;
        cell.Borders.Left.Width = 0.5;
        cell.Borders.Top.Width = 0.5;
        for (int i = 0; i < 5; i++)
        {
            Row rowEmpty = table.AddRow();
            cell = rowEmpty.Cells[0];
            cell = rowEmpty.Cells[0];
            cell.Borders.Right.Width = 0.5;
            cell.Borders.Left.Width = 0.5;
        }
        Row rowFinal = table.AddRow();
        cell = rowFinal.Cells[0];
        cell.AddParagraph("FIRMA");
        cell.Format.Alignment = ParagraphAlignment.Center;
        cell.VerticalAlignment = VerticalAlignment.Center;
        cell.Format.Font.Bold = true;
        cell.Format.Font.Size = 3;
        cell.Format.Font.Name = "Verdana";
        cell.Format.Font.Italic = true;
        cell.Borders.Right.Width = 0.5;
        cell.Borders.Left.Width = 0.5;
        cell.Borders.Bottom.Width = 0.5;
        return table;
    }
