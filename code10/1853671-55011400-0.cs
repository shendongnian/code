    // Load source PDF document
    Aspose.Pdf.Document document = new Aspose.Pdf.Document();
    // Add a page to the document
    Page page = document.Pages.Add();
    // Initializes a new instance of the Table
    Aspose.Pdf.Table table = new Aspose.Pdf.Table();
    // Set the table border color as LightGray
    table.Border = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
    // Set the border for table cells
    table.DefaultCellBorder = new Aspose.Pdf.BorderInfo(Aspose.Pdf.BorderSide.All, .5f, Aspose.Pdf.Color.FromRgb(System.Drawing.Color.LightGray));
    // Create a loop to add 10 rows
    for (int row_count = 1; row_count <= 10; row_count++)
    {
        // Add row to table
        Aspose.Pdf.Row row = table.Rows.Add();
        // Add table cells
        row.Cells.Add("Column (" + row_count + ", 1)");
        row.Cells.Add("Column (" + row_count + ", 2)");
    }
    // Add table object to first page of input document
    page.Paragraphs.Add(table);
    // Save updated document containing table object
    document.Save(dataDir + "Table_19.2.pdf");
