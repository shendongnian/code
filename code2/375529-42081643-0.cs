    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
    dlg.FileName = "Document";             
    dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
    if (dlg.ShowDialog() == true)
    {
        var encoder = new JpegBitmapEncoder(); // Or PngBitmapEncoder, or whichever encoder you want
        encoder.Frames.Add(BitmapFrame.Create(bi));
        using (var stream = dlg.OpenFile())
        {
             encoder.Save(stream);
        }
    }
