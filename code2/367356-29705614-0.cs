    InlineShape inlineShape = m_word.ActiveDocument.InlineShapes[m_i];
    inlineShape.Select();
    m_word.Selection.Copy();
    if (Clipboard.GetDataObject() != null)
    {
        IDataObject data = Clipboard.GetDataObject();
    
        if (data.GetDataPresent(DataFormats.Bitmap))
        {
            Image image = (Image)data.GetData(DataFormats.Bitmap,true);
    
            image.Save("image.bmp",System.Drawing.Imaging.ImageFormat.Bmp);
            image.Save("image.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
            image.Save("image.gif",System.Drawing.Imaging.ImageFormat.Gif);
        }
        else
        {
            MessageBox.Show("The Data In Clipboard is not as image format");
        }
    }
    else
    {
        MessageBox.Show("The Clipboard was empty");
    }
