                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                                {
                                    datatable.DefaultCell.BackgroundColor = iTextSharp.text.BaseColor.WHITE;
                                    datatable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                                    Phrase phrase = new Phrase(ds.Tables[0].Rows[i][j].ToString(), FontFactory.GetFont("Verdana", 9));
                                    datatable.AddCell(phrase);
                                }
                            }
    
    +                        PdfContentByte content = pdfStamper.GetUnderContent(2);
    
    +                        datatable.WriteSelectedRows(0, -1, 70.0f, 400.0f, content);
