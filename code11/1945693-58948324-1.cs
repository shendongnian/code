    void PrintDoc(object obj)
    {
        doc = new FlowDocument();
        doc.PageWidth = 96 * 8.5;
        doc.PageHeight = 96 * 11.7;
        doc.PagePadding = new Thickness(96, 96 * 1.7, 96, 96 * 1.1);
        var table = new Table();
        table.CellSpacing = 0;
        for (int i = 0; i < 6; i++)
        {
            var column = new TableColumn();
            if (i < 3) column.Width = new GridLength(70);
            else column.Width = new GridLength(138);
            table.Columns.Add(column);
        }
        var rowNum = 1;
        foreach (var item in Trade)
        {
            var rowGroup = new TableRowGroup();
            var row = new TableRow();
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.TransNo.ToString()))) { TextAlignment = TextAlignment.Center});
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.OrderNo.ToString()))) { TextAlignment = TextAlignment.Center});
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.Type))) { TextAlignment = TextAlignment.Center});
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.Price.ToString("N2")))) { TextAlignment = TextAlignment.Right});
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.Quantity.ToString("N0")))) { TextAlignment = TextAlignment.Right});
            row.Cells.Add(new TableCell(new Paragraph(new Run(item.ValueTraded.ToString("N2")))) { TextAlignment = TextAlignment.Right});
            if (rowNum % 2 == 0) row.Background = new SolidColorBrush(Colors.LightGray);
            rowGroup.Rows.Add(row);
            table.RowGroups.Add(rowGroup);
            rowNum++;
        }
        doc.Blocks.Add(table);
        PrintDialog dialog = new PrintDialog();
        dialog.CurrentPageEnabled = true;
        dialog.UserPageRangeEnabled = true;
        if (dialog.ShowDialog() == true)
        {
            var paginator = new FlowPaginator(doc, CustomerCode);
            dialog.PrintDocument(paginator, "");
        }
    }
