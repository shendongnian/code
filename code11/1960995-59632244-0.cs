    var reader = new PdfReader(templatePath);
                var ms = new MemoryStream();
                var pageSize = reader.GetPageSize(1);
                byte[] bytes;
                using (var stamper = new PdfStamper(reader, ms))
                {
                    var canvas = stamper.GetOverContent(1);
                    var bf = BaseFont.CreateFont(fontPath, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    //Date
                    canvas.BeginText();
                    canvas.SetFontAndSize(bf, 10);
                    canvas.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                        $"10/30/2018",
                        pageSize.GetRight(Utilities.MillimetersToPoints(26)),
                        pageSize.GetTop(Utilities.MillimetersToPoints(20.
                    canvas.EndText();
                    stamper.Close();
                    bytes = ms.ToArray();
                }
                return File(bytes, "application/pdf", "payment.pdf");
