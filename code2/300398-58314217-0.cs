      static PdfAccess()
        {
            Pdf.PdfDocument doc = Pdf.IO.PdfReader.Open(@"C:\...\ Contract.pdf", Pdf.IO.PdfDocumentOpenMode.Modify);
            Pdf.AcroForms.PdfAcroForm form = doc.AcroForm;
            if (form.Elements.ContainsKey("/NeedAppearances"))
            {
                form.Elements["/NeedAppearances"] = new PdfSharp.Pdf.PdfBoolean(true);
            }
            else
            {
                form.Elements.Add("/NeedAppearances", new PdfSharp.Pdf.PdfBoolean(true));
            }
           var name = (Pdf.AcroForms.PdfTextField)(form.Fields["Email"]);
           name.Value = new Pdf.PdfString("ramiboy");
            doc.Save(@"C:\...\ Contract.pdf");
            doc.Close();
