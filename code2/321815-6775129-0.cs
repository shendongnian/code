            try
            {
                using (var document = PdfiumViewer.PdfDocument.Load(@"input.pdf"))
                {
                    var image = document.Render(1, 300, 300, true);
                    image.Save(@"output.png", ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                // handle exception here;
            }
