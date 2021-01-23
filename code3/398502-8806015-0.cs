    public void PdfToJpegThumb(Stream srcStream, int pageNo, int maxDimension, Stream dstStream)
    {
        PdfDecoder decoder = new PdfDecoder();
        decoder.Resolution = 96; // reduce default resolution to speed up rendering
        // render page
        using (AtalaImage pdfimage = decoder.read(srcStream, pageNo, null)) {
            Thumbnail tn = new Thumbnail(maxDimension, maxDimension);
            // make a thumbnail image
            using (AtalaImage tnImage = tn.Create(pdfImage)) {
                // save it
                tnImage.Save(dstStream, new JpegEncoder(), null);
            }
        }
    }
               
