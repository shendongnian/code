    public static byte[] InsertTable(byte[] buffer, DataTable dt, int columns, float[] columnWidths)
		{
			using (MemoryStream inputPDF = new MemoryStream(buffer))
			using (MemoryStream outputPDF = new MemoryStream())
			{
				PdfReader reader = new PdfReader(inputPDF);
				iTextSharp.text.Document doc = new iTextSharp.text.Document();
				PdfWriter write = PdfWriter.GetInstance(doc, outputPDF);
				doc.Open();
				for (int i = 1; i <= reader.NumberOfPages; i++)
				{
					doc.NewPage();
					write.DirectContent.AddTemplate(write.GetImportedPage(reader, i), 1f, 0, 0, 1, 0, 0);
				}
				//adding my table
				PdfPTable t = new PdfPTable(columns);
				t.SetTotalWidth(columnWidths);
				foreach (DataRow dr in dt.Rows)
					foreach (object o in dr.ItemArray)
					{
						PdfPCell c = new PdfPCell();
						c.AddElement(new Chunk(o.ToString()));
						t.AddCell(c);
					}
				doc.NewPage();
				doc.Add(t);
				doc.Close();
				write.Close();
				reader.Close();
				return outputPDF.ToArray();
			}
		}
