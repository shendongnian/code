    public class PdfModule
    {
        private static readonly Font H1Font = new Font(Font.FontFamily.HELVETICA, 6, Font.BOLDITALIC);
        private static readonly Font H2Font = new Font(Font.FontFamily.HELVETICA, 6, Font.ITALIC);
        public static void CreateFile(string filename, DataTable data)
        {
            using (var msReport = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                using (var pdfDoc = new Document(PageSize.A5.Rotate(), 10f, 10f, 200f, 40f))
                {
                    using (PdfWriter.GetInstance(pdfDoc, msReport))
                    {
                        pdfDoc.Open();
                        var table = new PdfPTable(data.Columns.Count)
                        {
                            WidthPercentage = 100,
                            HeaderRows = 1
                        };
                        for (var k = 0; k < data.Columns.Count; k++)
                        {
                            var str =
                                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data
                                    .Columns[k].ColumnName.Replace("_", " ").ToLower());
                            ;
                            var cell = new PdfPCell(new Phrase(str, H1Font))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                VerticalAlignment = Element.ALIGN_CENTER
                            };
                            table.AddCell(cell);
                        }
                        for (var i = 0; i < data.Rows.Count; i++)
                        {
                            for (var j = 0; j < data.Columns.Count; j++)
                            {
                                var cell =
                                    new PdfPCell(new Phrase(data.Rows[i][j].ToString(), H2Font))
                                    {
                                        VerticalAlignment = Element.ALIGN_CENTER,
                                        HorizontalAlignment = data.Columns[j].DataType == typeof(decimal)
                                            ? Element.ALIGN_RIGHT
                                            : Element.ALIGN_LEFT
                                    };
                                table.AddCell(cell);
                            }
                        }
                        pdfDoc.Add(table);
                        pdfDoc.Close();
                    }
                }
            }
       }
    }
