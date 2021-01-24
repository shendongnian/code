 foreach (DataRow r in dtR.Rows)
                {
                    if (dtR.Rows.Count > 0)
                    {
                        //row 2
                        cell = new PdfPCell(new Phrase(r["inv_number"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["inv_date"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["due_date"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["ref_number"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["pastel_ref"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["status_id"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                        cell = new PdfPCell(new Phrase(r["invoice_total"].ToString(), subTitleFont)); cell.BorderColor = BaseColor.BLACK; table.AddCell(cell);
                    }
                }
