                // open the reader
                PdfReader reader = new PdfReader(oldFile);
                Rectangle size = reader.GetPageSizeWithRotation(1);
                Document document = new Document(size);
                // open the writer
                FileStream fs = new FileStream(newFile, FileMode.Create, FileAccess.Write);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();
                // the pdf content
                PdfContentByte cb = writer.DirectContent;
                // select the font properties
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb.SetFontAndSize(bf, 8);
                // write the text in the pdf content
                cb.BeginText();
                string text = $"Voided On - {DateTime.Now.Date.ToString("MM/dd/yyyy")}";
                // put the alignment and coordinates here
                cb.SetColorFill(BaseColor.RED); //Give Red color to the newly added Text only
                cb.ShowTextAligned(2, text, 120, 250, 0);
                cb.SetColorFill(BaseColor.BLACK);  //Give Red color to the exisitng file content only
                cb.EndText();
                // create the new page and add it to the pdf
                PdfImportedPage page = writer.GetImportedPage(reader, 1);
                cb.AddTemplate(page, 0, 0);
                document.Close();
                fs.Close();
                writer.Close();
                reader.Close();
            }
