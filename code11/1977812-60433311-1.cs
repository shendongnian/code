    using (PdfReader pdfReader = new PdfReader(PDF_SOURCE))
    {
        PdfSigner pdfSigner = new PdfSigner(pdfReader, File.Create(PDF_DEST), new StampingProperties().UseAppendMode());
        ImageData imageData = ImageDataFactory.Create(IMAGE_SOURCE);
        pdfSigner.SetFieldName("SH_SIGNATURE_417868");
        PdfSignatureAppearance sigAppearance = pdfSigner.GetSignatureAppearance();
        sigAppearance.SetContact("ContactInfo");
        sigAppearance.SetLocation("Location");
        sigAppearance.SetReason("SigningReason");
        sigAppearance.SetLayer2Text("Muddassir Awan");
        sigAppearance.SetSignatureGraphic(imageData);
        sigAppearance.SetRenderingMode(RenderingMode.GRAPHIC_AND_DESCRIPTION);
        sigAppearance.SetSignatureCreator("Muddassir Awan");
        int estimatedSize = 12000;
        pdfSigner.SignExternalContainer(new ExternalBlankSignatureContainer(PdfName.Adobe_PPKLite, PdfName.Adbe_pkcs7_detached), estimatedSize);
    }
