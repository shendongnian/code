    public void trickylabel(string fnsku, string title)
    {
        //Set barcode properties...
        code.parse(fnsku); // Text
        BCGDrawing drawing = new BCGDrawing(color_white);
        drawing.setBarcode(code);
        drawing.draw();
        // Draw (or save) the image into PNG format.
            
        using (var imageStream = new MemoryStream())
        {
            drawing.finish(ImageFormat.Png, imageStream);
            
            using (var result = new MemoryStream())
            {
                Document doc = new Document(new iTextSharp.text.Rectangle(200f, 75f), 20F, 10F, 10F, 1F);
                PdfWriter writer = PdfWriter.GetInstance(doc, result);
                doc.Open();
                var png = iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromStream(imageStream), ImageFormat.Png);
                doc.Add(png);
                //Sets pdf properties...
                doc.Add(new Paragraph(title, times));
                PdfAction action = new PdfAction(PdfAction.PRINTDIALOG);
                writer.SetOpenAction(action);
                doc.Close();
                Response.ContentType = "application/pdf";
                Response.AppendHeader("Content-Disposition", "attachment; filename=labels.pdf");
                Response.BinaryWrite(result.ToArray());
            }
        }
    }
