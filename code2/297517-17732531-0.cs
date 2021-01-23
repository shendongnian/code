    public static MemoryStream AddAutoPrint(Stream pdfStream, bool ShowPrintDialog = true, int NumCopies = 1)
    {
      PdfSharp.Pdf.PdfDocument doc = PdfSharp.Pdf.IO.PdfReader.Open(pdfStream, PdfSharp.Pdf.IO.PdfDocumentOpenMode.Import);
      PdfSharp.Pdf.PdfDocument outputDocument = new PdfSharp.Pdf.PdfDocument();
      for (int idx = 0; idx < doc.PageCount; idx++)
      {
        PdfSharp.Pdf.PdfPage p = doc.Pages[idx];
        outputDocument.AddPage(p);
      }
      outputDocument.Info.Author = "author name";
      string JSScript = string.Empty;
      JSScript += "var pp = this.getPrintParams(); ";
      
      if(NumCopies > 0)
      {
        JSScript += "pp.NumCopies = " + NumCopies.ToString() + "; ";
      }
      
      if(!ShowPrintDialog)
      {
         JSScript += "pp.interactive = pp.constants.interactionLevel.automatic; ";
      }
      JSScript += "this.print({printParams: pp}); ";
      PdfSharp.Pdf.PdfDictionary dictJS = new PdfSharp.Pdf.PdfDictionary();
      dictJS.Elements["/S"] = new PdfSharp.Pdf.PdfName("/JavaScript");
      //dictJS.Elements["/JS"] = new PdfSharp.Pdf.PdfStringObject(outputDocument, "print(true);");
      //dictJS.Elements["/JS"] = new PdfSharp.Pdf.PdfStringObject(outputDocument, "this.print({bUI: false, bSilent: true, bShrinkToFit: true});");
      //dictJS.Elements["/JS"] = new PdfSharp.Pdf.PdfStringObject(outputDocument, "var pp = this.getPrintParams(); pp.NumCopies = 2; pp.interactive = pp.constants.interactionLevel.automatic; this.print({printParams: pp});");
      dictJS.Elements["/JS"] = new PdfSharp.Pdf.PdfStringObject(outputDocument, JSScript);
      outputDocument.Internals.AddObject(dictJS);
      PdfSharp.Pdf.PdfDictionary dict = new PdfSharp.Pdf.PdfDictionary();
      PdfSharp.Pdf.PdfArray a = new PdfSharp.Pdf.PdfArray();
      dict.Elements["/Names"] = a;
      a.Elements.Add(new PdfSharp.Pdf.PdfString("EmbeddedJS"));
      a.Elements.Add(PdfSharp.Pdf.Advanced.PdfInternals.GetReference(dictJS));
      outputDocument.Internals.AddObject(dict);
      PdfSharp.Pdf.PdfDictionary group = new PdfSharp.Pdf.PdfDictionary();
      group.Elements["/JavaScript"] = PdfSharp.Pdf.Advanced.PdfInternals.GetReference(dict);
      outputDocument.Internals.Catalog.Elements["/Names"] = group;
      MemoryStream ms = new MemoryStream();
      outputDocument.Save(ms, false);
      return ms;
    }
