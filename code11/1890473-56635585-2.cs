    using (PdfReader reader = new PdfReader(SRC))
    using (FileStream os = new FileStream(DEST, FileMode.Create))
    {
        PdfStamper stamper = PdfStamper.CreateSignature(reader, os, '\0');
        // Creating the appearance
        PdfSignatureAppearance appearance = stamper.SignatureAppearance;
        appearance.Reason = "MyRes";
        appearance.Location = "MyLoc";
        appearance.SetVisibleSignature(new Rectangle(36, 748, 250, 400), 1, "SIG");
        // Creating the signature
        CustomExternalSignature pks = new CustomExternalSignature();
        MakeSignature.SignDetached(appearance, pks, pks.GetChain(), null, null, null, 0, CryptoStandard.CMS);
    }
