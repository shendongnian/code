		RenderTargetBitmap rtb = new RenderTargetBitmap((int)(renderWidth * dpiX / 96.0),
														(int)(renderHeight * dpiY / 96.0),
														dpiX,
														dpiY,
														PixelFormats.Pbgra32);
			DrawingVisual dv = new DrawingVisual();
			using (DrawingContext ctx = dv.RenderOpen())
			{
			   VisualBrush vb = new VisualBrush(target);
			   ctx.DrawRectangle(vb, null, new System.Windows.Rect(new Point(0, 0), new Point(bounds.Width, bounds.Height)));
			}
			rtb.Render(dv);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
