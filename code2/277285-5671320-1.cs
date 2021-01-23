    // write everything out to the baos.
    doc.close(); 
    // and suck it right back up again.  Hurray for efficiency.  Or something.
    PdfReader reader = new PdfReader(baos.toByteArrayOrWhateverItsCalled());
    PdfStamper stamper = new PdfStamper( reader, new FileOutputStream(outputPath));
    // duplicate the pages.  I'll assume only one page, but you'll get the idea.
    PdfDictionary origPage = reader.getPageN(1);
    for (int i = 0; i < 2; ++i) {
      // initial size is irrelevant, we're going to change it, but !null
      stamper.insertPage(2+i, PageSize.LETTER); 
      PdfDictionary newPageDict = reader.getPage(2 + i);
      // copy the original page... note that this is a shallow copy
      newPageDict.putAll(origPageDict);
      // duplicate the page rect so each page will have its own copy
      PdfArray pageRect = newPageDict.getAsArray(PdfName.MEDIABOX);
      // also a shallow copy, but changes to this array will be localized to the page.
      PdfArray newRect = new PdfArray(pageRect);
      // page rects are defined as [llx lly urx ury], so we need to change 0 and 2.
      newRect.set(0, new PdfNumber(origWidth * (i+1));
      newRect.set(2, new PdfNumber(origWidth * (i+2));
    }
    //Smoke'em if you've got 'em folks, we're done.
    stamper.close();
