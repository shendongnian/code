    PdfReader r = new PdfReader(@"d:\kb2\" + f);
    for (int i = 1; i <= r.NumberOfPages; i++) {
        //Get the current page
        var PageDictionary = r.GetPageN(i);
        //Get all of the annotations for the current page
        var Annots = PageDictionary.GetAsArray(PdfName.ANNOTS);
        //Make sure we have something
        if ((Annots == null) || (Annots.Length == 0))
            continue;
        foreach (var A in Annots.ArrayList) {
            var AnnotationDictionary = PdfReader.GetPdfObject(A) as PdfDictionary;
            if (AnnotationDictionary == null)
                continue;
            //Make sure this annotation has a link
            if (!AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK))
                continue;
            //Make sure this annotation has an ACTION
            if (AnnotationDictionary.Get(PdfName.A) == null)
                continue;
            var annotActionObject = AnnotationDictionary.Get(PdfName.A);
            var AnnotationAction = (PdfDictionary)(annotActionObject.IsIndirect() ? PdfReader.GetPdfObject(annotActionObject) : annotActionObject); 
                        
            var type = AnnotationAction.Get(PdfName.S);
            //Test if it is a URI action
            if (type.Equals(PdfName.URI)) {
                //Change the URI to something else
                string relativeRef = AnnotationAction.GetAsString(PdfName.URI).ToString();
                AnnotationAction.Put(PdfName.URI, new PdfString(url));
            } else if (type.Equals(PdfName.LAUNCH)) {
                //Change the URI to something else
                var filespec = AnnotationAction.GetAsDict(PdfName.F);
                string url = filespec.GetAsString(PdfName.F).ToString();
                AnnotationAction.Put(PdfName.F, new PdfString(url));
            }
        }
    }
    //Next we create a new document add import each page from the reader above
    using (var output = File.OpenWrite(outputFile.FullName)) {
        using (Document Doc = new Document()) {
            using (PdfCopy writer = new PdfCopy(Doc, output)) {
                Doc.Open();
                for (int i = 1; i <= r.NumberOfPages; i++) {
                    writer.AddPage(writer.GetImportedPage(r, i));
                }
                Doc.Close();
            }
        }
    }
    r.Close();
