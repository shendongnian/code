            gettable();
        }
        void gettable()
        {
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Vedic-Chart-Life-Report.pdf"), FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                Document doc = new Document(PageSize.LETTER);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                doc.Open();
                doc.NewPage();
                
                BaseFont bf = BaseFont.CreateFont("C:/WINDOWS/Fonts/krdv010.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                Font f = new Font(bf, 16, Font.BOLD);
                PdfContentByte cb = writer.DirectContent;
                cb.MoveTo(0, doc.PageSize.Height - 20);
                cb.LineTo(doc.PageSize.Width, doc.PageSize.Height - 20);
                cb.Stroke();
                cb.ClosePathStroke();
                PdfPTable table = new PdfPTable(1);
                PdfPCell cell = new PdfPCell(new Phrase("eaxynks'k foospu", f));
                // Give our rows some height so we can see test vertical alignment.
                cell.FixedHeight = 15f;
                cell.HorizontalAlignment = 1;
                cell.VerticalAlignment = Element.ALIGN_TOP;
                table.AddCell(cell);
                doc.Add(table);
                //cb.RoundRectangle(10f, 550f, 592f, 200f, 20f);
                //cb.Stroke();
                //doc.Add(new Phrase("eaxynks'k foospu", f));
                
                doc.Close();
            }
        }
