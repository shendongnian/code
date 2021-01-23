    // adding content to iTextSharp Document instance
                    PdfPTable table = new PdfPTable(3);
                    //actual width of table in points
                    table.TotalWidth = 500f;
                    //fix the absolute width of the table
                    table.LockedWidth = true;
                    //relative col widths in proportions 
                    float[] widths = new float[] { 1f, 2f, 1f };
                    table.SetWidths(widths);
                    table.HorizontalAlignment = 0;
                    //leave a gap before and after the table
                    table.SpacingBefore = 20f;
                    table.SpacingAfter = 10f;
    
      //Start Heading
                    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("No.", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD)) });
                    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("Item Name", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD)) });
                    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("Description", new Font(Font.FontFamily.HELVETICA, 8f, Font.BOLD)) });
    
    // Table content
    //Here we can use a loop to add multiple rows
    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("1", new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL)) });
                    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("Register Book"), new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL)) });
                    table.AddCell(new PdfPCell() { BorderColor = BaseColor.LIGHT_GRAY, Phrase = new Phrase("Used to manage the details"), new Font(Font.FontFamily.HELVETICA, 8f, Font.NORMAL)) });
