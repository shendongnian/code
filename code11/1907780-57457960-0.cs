    PdfReader reader = new PdfReader(this.txtPdf.Text);
    PdfDictionary pageDict = reader.GetPageN(reader.NumberOfPages);
    PdfArray annotArray = pageDict.GetAsArray(PdfName.ANNOTS);
    
    //Console.WriteLine("Annotation count:{0}", annotArray.Size);
    for (int i = 0; i < annotArray.Size; i++)
    {
        PdfObject annot = annotArray.GetDirectObject(i);
        //Console.WriteLine(annot.ToString());
        bool btmp = annot.IsDictionary();
        if (btmp)
        {
            PdfDictionary pdfDic = ((PdfDictionary)annot);
            PdfName stamp = pdfDic.GetAsName(PdfName.SUBTYPE);
            if (stamp.Equals(PdfName.STAMP))
            {
                // rects are laid out [llx, lly, urx, ury]
                float x, y, width, height;
                PdfArray rect = pdfDic.GetAsArray(PdfName.RECT);
                x = rect.GetAsNumber(0).FloatValue;
                y = rect.GetAsNumber(1).FloatValue;
                width = rect.GetAsNumber(2).FloatValue - x;
                height = rect.GetAsNumber(3).FloatValue - y;
    
                PdfDictionary appearancesDic = pdfDic.GetAsDict(PdfName.AP);
                PdfStream normalAppearance = appearancesDic.GetAsStream(PdfName.N);
                PdfDictionary resourcesDic = ormalAppearance.GetAsDict(PdfName.RESOURCES);
    
                ImageRenderListener listener = new ImageRenderListener();
                PdfContentStreamProcessor processor = new PdfContentStreamProcessor(listener);
                processor.ProcessContent(
                    ContentByteUtils.GetContentBytesFromContentObject(normalAppearance), 				 resourcesDic);
    
                System.Drawing.Image drawingImage = listener.Images.First();
                //Image image = Image.GetInstance(drawingImage, drawingImage.RawFormat);
            }
        }
    }
