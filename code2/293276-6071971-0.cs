    for (int i = 0; i < widths.Length / 2; i++)
    {
        PdfPCell materia = new PdfPCell(new Phrase("MATERIA", font));
        materia.Rowspan = 1;
        materia.Colspan = 2;
        materia.HorizontalAlignment = 1;
        materia.VerticalAlignment = 1;
        table.AddCell(materia);
    }
