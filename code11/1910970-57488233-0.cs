Paragraph c1 = new Paragraph("SUBMITTED BY: "+ "\n\n" + "\n", head3);
            c1 = new Paragraph();
            c1.Add(new Chunk("SUBMITTED BY : ", head3));
            c1.Add(Chunk.TABBING);
            c1.Add(Chunk.TABBING);
            c1.Add(Chunk.TABBING);
            c1.Add(Chunk.TABBING);
            c1.Add(new Chunk("ACKNOWLEDGED/TAKEN BY : ", head3));
The Chunk.TABBING will create a space in between the text. As per picture below :
[![enter image description here][1]][1]
While to adjust cell width size , depending on how you convert your DataGridView into a PDF or such , here's the code :
PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
float[] widths1 = new float[] { 5f, 30f, 30f, 5f, 15f, 30f, 30f };
pdfTable.SetWidths(widths1);
foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                iTextSharp.text.Font header1 = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, header1)) { BorderWidth = 1, VerticalAlignment = Element.ALIGN_MIDDLE, HorizontalAlignment = Element.ALIGN_CENTER };
                //cell.BackgroundColor = new iTextSharp.text.Color(240, 240, 240);
                pdfTable.AddCell(cell);
            }
I created my pdftable with the columcount i have in DataGridView.
With this , i manually adjust the size of each columns width using float array. Picture above is already using this method.
  [1]: https://i.stack.imgur.com/nt9tK.png
