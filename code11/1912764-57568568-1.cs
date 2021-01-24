		 PdfDocument doc = new PdfDocument(); 
		  doc.LoadFromFile(@"..\..\Sample1.pdf");
		 foreach (PdfPageBase page in doc.Pages) 
					{ 
						PdfTilingBrush brush 
						   = new PdfTilingBrush(new SizeF(page.Canvas.ClientSize.Width / 2, page.Canvas.ClientSize.Height / 3)); 
						brush.Graphics.SetTransparency(0.3f); 
						brush.Graphics.Save(); 
						brush.Graphics.TranslateTransform(brush.Size.Width / 2, brush.Size.Height / 2); 
						brush.Graphics.RotateTransform(-45); 
						brush.Graphics.DrawString("MSDN Samples", 
							new PdfFont(PdfFontFamily.Helvetica, 24), PdfBrushes.Violet, 0, 0, 
							new PdfStringFormat(PdfTextAlignment.Center)); 
						brush.Graphics.Restore(); 
						brush.Graphics.SetTransparency(1); 
						page.Canvas.DrawRectangle(brush, new RectangleF(new PointF(0, 0), page.Canvas.ClientSize)); 
					}
		 doc.SaveToFile("TextWaterMark.pdf"); 
