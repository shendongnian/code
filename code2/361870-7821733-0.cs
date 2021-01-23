    System.Windows.Media.Imaging.RenderTargetBitmap renderTarget = myParent.GetViewPortAsImage(DiagramSizeX, DiagramSizeY);
    System.Windows.Media.Imaging.BitmapEncoder encoder = new System.Windows.Media.Imaging.PngBitmapEncoder();
    MemoryStream myStream = new MemoryStream();
    encoder.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(renderTarget));
    encoder.Save(myStream);
    //
    System.Drawing.Bitmap pg = new System.Drawing.Bitmap(DiagramSizeX, DiagramSizeY);
    System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(pg);
    //
    // Background
    //
    gr.FillRectangle(new System.Drawing.SolidBrush(BKGC), 0, 0, DiagramSizeX, DiagramSizeY);
    //
    gr.DrawImage(System.Drawing.Bitmap.FromStream(myStream), 0, 0);
    System.Windows.Forms.Clipboard.SetDataObject(pg, true);
    sheet.Paste(range);
