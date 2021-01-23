    public void EncryptPdf(Stream input, Stream output, string userPassword, string ownerPassword)
    {
        if (input == output) throw new ArgumentExeption("input", "input and output must be different");
        PdfDocument doc = new PdfDocument(input);
        // at this point if you set doc.Permissions, you can fine-control what can be
        // done to the document.  If userPassword is null, then the document can be opened
        // without a password prompt, but will be restricted to the permissions.
        // Permissions includes things like Printing, Modifying, Copying Text etc.
        doc.Save(userPassword, ownerPassword, output);
    }
