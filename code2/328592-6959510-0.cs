        private static List<string> GetPdfLinks(string file, int page)
        {
            //Open our reader
            PdfReader R = new PdfReader(file);
            //Get the current page
            PdfDictionary PageDictionary = R.GetPageN(page);
            //Get all of the annotations for the current page
            PdfArray Annots = PageDictionary.GetAsArray(PdfName.ANNOTS);
            //Make sure we have something
            if ((Annots == null) || (Annots.Length == 0))
                return null;
            List<string> Ret = new List<string>();
            //Loop through each annotation
            foreach (PdfObject A in Annots.ArrayList)
            {
                //Convert the itext-specific object as a generic PDF object
                PdfDictionary AnnotationDictionary = (PdfDictionary)PdfReader.GetPdfObject(A);
                //Make sure this annotation has a link
                if (!AnnotationDictionary.Get(PdfName.SUBTYPE).Equals(PdfName.LINK))
                    continue;
                //Make sure this annotation has an ACTION
                if (AnnotationDictionary.Get(PdfName.A) == null)
                    continue;
                //Get the ACTION for the current annotation
                PdfDictionary AnnotationAction = (PdfDictionary)AnnotationDictionary.Get(PdfName.A);
                //Test if it is a URI action (There are tons of other types of actions, some of which might mimic URI, such as JavaScript, but those need to be handled seperately)
                if (AnnotationAction.Get(PdfName.S).Equals(PdfName.URI))
                {
                    PdfString Destination = AnnotationAction.GetAsString(PdfName.URI);
                    if (Destination != null)
                        Ret.Add(Destination.ToString());
                }
            }
            return Ret;
        }
