    public static byte[] ExtractPKCS7From(string path)
    {
        AcroFields acroFields = new PdfReader(path).AcroFields;
        List<string> names = acroFields.GetSignatureNames();
        
        foreach(var name in names)
        {
            PdfDictionary dict = acroFields.GetSignatureDictionary(name);
            PdfString contents =
                (PdfString)PdfReader.GetPdfObject(dict.Get(PdfName.CONTENTS));
            return contents.GetOriginalBytes();
        }
        return null;
    }
