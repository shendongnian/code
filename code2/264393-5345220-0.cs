                    cb.PdfDocument.NewPage();
                    PdfImportedPage page1 = writer.GetImportedPage(reader, i);
                    Rectangle psize = reader.GetPageSizeWithRotation(i);
                    switch (psize.Rotation)
                    {
                        case 0:
                            cb.AddTemplate(page1, 1f, 0, 0, 1f, 0, 0);
                            break;
                        case 90:
                            cb.AddTemplate(page1, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
                            break;
                        case 180:
                            cb.AddTemplate(page1, -1f, 0, 0, -1f, 0, 0);
                            break;
                        case 270:
                            cb.AddTemplate(page1, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(1).Width, 0);
                            break;
                        default:
                            break;
                    }
