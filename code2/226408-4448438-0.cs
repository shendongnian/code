        Dim Doc As Document = New Document(PageSize.A4.Rotate(), 0, 0, 15, 5)
        Dim paragraphTable1 As New Paragraph
        Dim mainTable As New iTextSharp.text.pdf.PdfPTable(3)
        paragraphTable1.SpacingAfter = 15.0F
        Dim table As New PdfPTable(3)
        Dim cell As New PdfPCell(New Phrase("This is table 1"))
        cell.Colspan = 3
        cell.HorizontalAlignment = 1
        table.AddCell(cell)
        table.AddCell("Col 1 Row 1")
        table.AddCell("Col 2 Row 1")
        table.AddCell("Col 3 Row 1")
        mainTable.AddCell(table)
        Dim paragraphTable2 As New Paragraph
        paragraphTable2.SpacingAfter = 10.0F
        Dim table1 As New PdfPTable(3)
        cell = New PdfPCell(New Phrase("This is table 2"))
        cell.Colspan = 3
        cell.HorizontalAlignment = 1
        table1.AddCell(cell)
        table1.AddCell("Col 1111 Row 1")
        table1.AddCell("Col 2222 Row 1")
        table1.AddCell("Col 3333 Row 1")
        mainTable.AddCell(table1)
        'paragraphTable2.Add(table1)
        Dim writer As PdfWriter = PdfWriter.GetInstance(Doc, Response.OutputStream)
        writer.GetVerticalPosition(True)
        Doc.Open()
        table.WidthPercentage = 30%
        table.SpacingBefore = 10.0F
        table.HorizontalAlignment = Element.ALIGN_LEFT
        table1.WidthPercentage = 30%
        table1.SpacingBefore = 10.0F
        table1.HorizontalAlignment = Element.ALIGN_RIGHT
        Doc.Add(table)
        Doc.Add(table1)
        Doc.Close()
        Response.ContentType = "application/pdf"
        Response.AddHeader("content-disposition", "attachment; filename= pdfff.pdf")
        Response.[End]()
