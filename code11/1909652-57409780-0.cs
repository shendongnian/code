            foreach(DataGridViewColumn column in dgv.Columns)
            {
                if (!column.Visible) continue;
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }
            //add datarow
            foreach(DataGridViewRow row in dgv.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (!dgv.Columns[cell.ColumnIndex].Visible) continue;
                    //dgv.Columns[7].Visible = false;
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }
