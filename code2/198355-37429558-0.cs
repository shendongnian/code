     // create your own paginator instead of this
     // this is my specific own implementation for DocumentPaginator class
     ReportPaginator paginator = new ReportPaginator(report);
     Visual visual = paginator.GetPage(0).Visual;  // first page - loop for all
     RenderTargetBitmap bmp = new RenderTargetBitmap((int)paginator.PageSize.Width, (int)paginator.PageSize.Height, 96d, 96d, PixelFormats.Default);
     bmp.Render(visual);
     PngBitmapEncoder png = new PngBitmapEncoder();
     png.Frames.Add(BitmapFrame.Create(bmp));
     using (MemoryStream sm = new MemoryStream())
     {
         png.Save(sm);
         return sm.ToArray();
     }
