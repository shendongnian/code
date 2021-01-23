    string templateDocPath = Server.MapPath("~/Documents/MyTemplate.pdf");
    PdfDocument myTemplate = PdfReader.Open(templateDocPath, PdfDocumentOpenMode.Modify);
    PdfAcroForm form = myTemplate.AcroForm;
    
    if (form.Elements.ContainsKey("/NeedAppearances"))
    {
        form.Elements["/NeedAppearances"] = new PdfSharp.Pdf.PdfBoolean(true);
    }
    else
    {
        form.Elements.Add("/NeedAppearances", new PdfSharp.Pdf.PdfBoolean(true));
    }
    
    PdfTextField testField = (PdfTextField)(form.Fields["TestField"]);
    testField.Text = "012345";
    
    myTemplate.Save(Server.MapPath("~/Documents/Amended.pdf"));  // Save to new file.
