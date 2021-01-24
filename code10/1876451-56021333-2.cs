    PdfDictionary GetAsDictAndMarkUsed(PdfStamperImp writer, PdfDictionary dictionary, params PdfName[] names)
    {
        PRIndirectReference reference = null;
        foreach (PdfName name in names)
        {
            if (dictionary != null)
            {
                dictionary = dictionary.GetDirectObject(name) as PdfDictionary;
                if (dictionary != null)
                {
                    if (dictionary.IndRef != null)
                        reference = dictionary.IndRef;
                }
            }
        }
        if (reference != null)
            writer.MarkUsed(reference);
        return dictionary;
    }
