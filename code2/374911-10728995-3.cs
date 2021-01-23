    // code to iterate over PDF objects and get bytes of a valid image elided
    var imageBytes = GetRawImageBytesFromPdf();
    
    if (filterType.Equals(PdfName.JBIG2DECODE))
    {
        var jbg2 = new JBIG2Decoder();
        // Some JBig2 will extract without setting the JBig2Globals
        var decodeParams = stream.GetAsDict(PdfName.DECODEPARMS);
        if(decodeParams != null)
        {
            var globalRef = decodeParams.GetAsIndirectObject(
                                            PdfName.JBIG2GLOBALS);
            if(globalRef != null)
            {
                var globals = PdfReader.GetPdfObject(globalRef);
                var globalStream = globals as PRStream;
                var globalBytes = PdfReader.GetStreamBytesRaw(globalStream);
                if (globalBytes != null)
                {
                    jbg2.setGlobalData(globalBytes);
                }
            }
        }
        jbg2.decodeJBIG2(imageBytes);
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
