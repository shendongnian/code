    using (PdfDocument document = new PdfDocument())
            {
                document.PageSettings.Size = new SizeF(612, 350);
                document.PageSettings.Orientation = PdfPageOrientation.Landscape;
                document.PageSettings.SetMargins(0);
                // Add a page to the document
                PdfPage page = document.Pages.Add();
        
                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;
                var qrImage = DependencyService.Get<IBarcodeService>().ConvertImageStream(Vin);
                PdfBitmap image = new PdfBitmap(qrImage);
        
                graphics.DrawImage(image, 300, -50, 350, 350);
            }
