    using (PDFDoc doc = new PDFDoc("2002.04610.pdf"))
    {
        doc.InitSecurityHandler();
        int xrefSz = doc.GetSDFDoc().XRefSize();
        for (int xrefCounter = 0; xrefCounter < xrefSz; ++xrefCounter)
        {
            Obj o = doc.GetSDFDoc().GetObj(xrefCounter);
            if (o.IsFree())
            {
                continue;
            }
            if(o.IsStream())
            {
                Obj subtypeObj = o.FindObj("Subtype");
                if (subtypeObj != null)
                {
                    string subtype = "";
                    if(subtypeObj.IsName()) subtype = subtypeObj.GetName();
                    if(subtypeObj.IsString()) subtype = subtypeObj.GetAsPDFText(); // Subtype should be a Name, but just in case
                    if (subtype.CompareTo("Image") == 0)
                    {
                        Console.WriteLine("Indirect object {0} is an Image Stream", o.GetObjNum());
                    }
                }
            }
        }
    }
