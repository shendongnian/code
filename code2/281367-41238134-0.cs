              byte[] bPDF = null;
    MemoryStream ms = new MemoryStream();
    Document document = new Document(); //pdf document to write
       var originalpath = HostingEnvironment.MapPath("~/PDFs/");
                    if (!System.IO.Directory.Exists(originalpath))
                        Directory.CreateDirectory(originalpath);
                    // Create a new PdfWriter object, specifying the outputstream
    
                    var pdfwriter = PdfWriter.GetInstance(document, ms);
    
                    // Open the Document for writing
                    document.Open();
                    PdfPTable ParentTable = new PdfPTable(1);
                     ParentTable.TotalWidth = 500f;
                                 ParentTable.LockedWidth = true;
                    ParentTable.HorizontalAlignment = 0;
                    ParentTable.ExtendLastRow = false;
                    PdfPCell heading = new PdfPCell(new Phrase("", HeaderFont));
                    heading.PaddingBottom = 0f;
                    heading.PaddingTop = 0f;
                    heading.Border = 1;
                    ParentTable.AddCell(heading);
                    PdfPTable dataTableCellHeaderTable = new PdfPTable(3);
                    dataTableCellHeaderTable.HorizontalAlignment = 0;
                    float[] widths = new float[] { 2f, 2f, 5f };
                    dataTableCellHeaderTable.SetWidths(widths);
                  PdfPCell cellSerialNumber = new PdfPCell(new Phrase(ScoringColoringModel.pdfFirstCellHeading, tableHeaderCellFont)) { Border = 0 };
                    cellSerialNumber.PaddingTop = 7.5f;
                    cellSerialNumber.PaddingBottom = 7.5f;
                    cellSerialNumber.BorderColor = BaseColor.WHITE;
                    cellSerialNumber.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3").ToArgb());
                    dataTableCellHeaderTable.AddCell(cellSerialNumber);
    
    
                    PdfPCell cellRegistration = new PdfPCell(new Phrase(ScoringColoringModel.pdfSecondCellHeading, tableHeaderCellFont)) { Border = PdfPCell.LEFT_BORDER };
                    cellRegistration.PaddingTop = 7.5f;
                    cellRegistration.PaddingBottom = 7.5f;
                    cellRegistration.BorderColor = BaseColor.WHITE;
                    cellRegistration.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3").ToArgb());
                    dataTableCellHeaderTable.AddCell(cellRegistration);
    
                    PdfPCell cellwordMark = new PdfPCell(new Phrase(ScoringColoringModel.pdfThirdCellHeading, tableHeaderCellFont)) { Border = PdfPCell.LEFT_BORDER };
                    cellwordMark.PaddingTop = 7.5f;
                    cellwordMark.PaddingBottom = 7.5f;
                    cellwordMark.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#D3D3D3").ToArgb());
                    cellwordMark.BorderColor = BaseColor.WHITE;
                    dataTableCellHeaderTable.AddCell(cellwordMark);
                    // to append more data create one table
                    PdfPTable datatable = new PdfPTable(3);
    
                    Font cellColor = new Font();
    
                    foreach (DataRow dr in objDataTable.Rows)
                    {
    
                        if (dr.ItemArray[5].ToString() == "Yellow")
                        {
    
                            cellColor = FontFactory.GetFont(ScoringColoringModel.pdfFontSet, 12, new BaseColor(System.Drawing.ColorTranslator.FromHtml("#ffa800").ToArgb())); ;
    
                        }
                        else
                        {
                            cellColor = FontFactory.GetFont(ScoringColoringModel.pdfFontSet, 12, new BaseColor(System.Drawing.ColorTranslator.FromHtml(dr.ItemArray[5].ToString()).ToArgb())); ;
                        }
    
                        dataTableCellHeaderTable.AddCell(new PdfPCell(new Phrase(dr.ItemArray[0].ToString(), cellColor)) { PaddingBottom = 5, Border = 1, PaddingTop = 5 });
    
                   
    
             dataTableCellHeaderTable.AddCell(new PdfPCell(new Phrase(dr.ItemArray[1].ToString(), cellColor)) { PaddingBottom = 5, Border = 1, PaddingTop = 5 });
        
                            dataTableCellHeaderTable.AddCell(new PdfPCell(new Phrase(dr.ItemArray[3].ToString(), cellColor)) { PaddingBottom = 5, Border = 1, PaddingTop = 5 });
        
                        }
        //Here you can add multiple table 
        
        
        
        
        
                      document.Add(ParentTable);
        //document.Add(ParentTable1); and add table one by one to the document 
        
                        document.Close();
                        bPDF = ms.ToArray();
                        // Close the writer instance
        
                        Response.ContentType = "application/pdf";
                        Response.AddHeader("content-disposition", "attachment;filename=TrademarkSearchResult.pdf");
                        Response.BinaryWrite(bPDF);
                        Response.End();
                    }`enter code here`
