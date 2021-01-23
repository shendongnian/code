    string image_name = "temp.bmp";
    IHTMLDocument2 document = (IHTMLDocument2)webBrowser1.Document.DomDocument;
    IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)document.body).createControlRange();
    imgRange.add(document.all.item(HTML_IMAGE_ID));
    imgRange.execCommand("Copy");
    using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
    {
          bmp.Save(image_name);
    }
