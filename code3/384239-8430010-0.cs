    public static UIImageView GetLowResPagePreview (CGPDFPage oPdfPage, RectangleF oTargetRect)
    		{
    			RectangleF oOriginalPdfPageRect = oPdfPage.GetBoxRect (CGPDFBox.Media);
    			RectangleF oPdfPageRect = PdfViewerHelpers.RotateRectangle( oPdfPage.GetBoxRect (CGPDFBox.Media), oPdfPage.RotationAngle);
    			
    			// Create a low res image representation of the PDF page to display before the TiledPDFView
    			// renders its content.
    			int iWidth = Convert.ToInt32 ( oPdfPageRect.Size.Width );
    			int iHeight = Convert.ToInt32 ( oPdfPageRect.Size.Height );
    			CGColorSpace oColorSpace = CGColorSpace.CreateDeviceRGB();
    			CGBitmapContext oContext = new CGBitmapContext(null, iWidth, iHeight, 8, iWidth * 4, oColorSpace, CGImageAlphaInfo.PremultipliedLast);
    			
    			// First fill the background with white.
    			oContext.SetFillColor (1.0f, 1.0f, 1.0f, 1.0f);
    			oContext.FillRect (oOriginalPdfPageRect);
    			// Scale the context so that the PDF page is rendered 
    			// at the correct size for the zoom level.
    			oContext.ConcatCTM ( oPdfPage.GetDrawingTransform ( CGPDFBox.Media, oPdfPageRect, 0, true ) );
    			oContext.DrawPDFPage (oPdfPage);
    			CGImage oImage = oContext.ToImage();
    			UIImage oBackgroundImage = UIImage.FromImage( oImage );
    			oContext.Dispose();
    			oImage.Dispose ();
    			oColorSpace.Dispose ();
    			
    			UIImageView oBackgroundImageView = new UIImageView (oBackgroundImage);
    			oBackgroundImageView.Frame = new RectangleF (new PointF (0, 0), oPdfPageRect.Size);
    			oBackgroundImageView.ContentMode = UIViewContentMode.ScaleToFill;
    			oBackgroundImageView.UserInteractionEnabled = false;
    			oBackgroundImageView.AutoresizingMask = UIViewAutoresizing.None;
    			return oBackgroundImageView;
    		}
