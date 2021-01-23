        private bool Test(string pdf_file) 
        {
            bool ret = false;
            Document doc = new Document(PageSize.A4);
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdf_file, FileMode.Create));
                doc.Open();
                PdfPTable table = new PdfPTable(3);
                PdfPCell cell = new PdfPCell(new Phrase("Header Column"));
                cell.Colspan = 3;
                cell.HorizontalAlignment = 1; 
                table.AddCell(cell);
                table.AddCell("row1:col1");
                table.AddCell("row1:col2");
                table.AddCell("row1:col3");
                doc.Add(table);
                ret = true;
            }
            catch (DocumentException de)
            {
                MessageBox.Show(de.Message);
            }
            catch (IOException ioe)
            {
                MessageBox.Show(ioe.Message);
            }
            doc.Close();
            if(ret)
                MessageBox.Show("File has been created");
            return ret;
        }
