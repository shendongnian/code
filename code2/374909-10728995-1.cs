    // code to iterate over PDF objects and get bytes of a valid image elided
    
    if (filterType.Equals(PdfName.JBIG2DECODE))
    {
        var jbg2 = new JBIG2Decoder();
        // using iTextSharp.text.pdf.codec
        var globalData = JBIG2Image.GetGlobalSegment(
                                        new RandomAccessFileOrArray(bytes));
        if(globalData != null)
            jbg2.setGlobalData(globalData);
        jbg2.decodeJBIG2(bytes);
        var pages = jbg2.getNumberOfPages();
        for(int p = 0; p < pages; p++)
        {
            java.awt.image.BufferedImage bufImg = jbg2.getPageAsBufferedImage(p);
            var bitmap = bufImg.getBitmap();
            bitmap.Save(@"c:\path\to\file.tif", ImageFormat.Tiff);
            // note: I am unsure about the need to free the memory of the internal
            //       bitmap used in the BufferedImage class.  The docs for IKVM and
            //       that class should probably be consulted to find out if that
            //       should be done.
        }
    }
    // handle other formats like CCITTFAXDECODE
