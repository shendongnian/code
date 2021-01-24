    using (PdfReader pdfReader = new PdfReader(PDF_SOURCE))
    {
        PdfSigner pdfSigner = new PdfSigner(pdfReader, File.Create(PDF_DEST), new StampingProperties().UseAppendMode());
        ImageData signatureImageData = ImageDataFactory.Create(IMAGE_SOURCE);
        Image signatureImage = new Image(signatureImageData);
        pdfSigner.SetFieldName("SH_SIGNATURE_417868");
        PdfSignatureAppearance sigAppearance = pdfSigner.GetSignatureAppearance();
        sigAppearance.SetContact("ContactInfo");
        sigAppearance.SetLocation("Location");
        sigAppearance.SetReason("SigningReason");
        sigAppearance.SetSignatureCreator("Muddassir Awan");
        PdfPage page = pdfSigner.GetDocument().GetPage(sigAppearance.GetPageNumber());
        int rotation = page.GetRotation();
        PdfFormXObject layer2Object = sigAppearance.GetLayer2();
        Rectangle rect = layer2Object.GetBBox().ToRectangle();
        PdfCanvas pdfCanvas = new PdfCanvas(layer2Object, pdfSigner.GetDocument());
        if (rotation == 90)
            pdfCanvas.ConcatMatrix(0, 1, -1, 0, rect.GetWidth(), 0);
        else if (rotation == 180)
            pdfCanvas.ConcatMatrix(-1, 0, 0, -1, rect.GetWidth(), rect.GetHeight());
        else if (rotation == 270)
            pdfCanvas.ConcatMatrix(0, -1, 1, 0, 0, rect.GetHeight());
        Rectangle rotatedRect = 0 == (rotation / 90) % 2 ? new Rectangle(rect.GetWidth(), rect.GetHeight()) : new Rectangle(rect.GetHeight(), rect.GetWidth());
        Canvas appearanceCanvas = new Canvas(pdfCanvas, pdfSigner.GetDocument(), rotatedRect);
        Paragraph text = new Paragraph();
        text.SetFontSize(7).Add("Signed by: Muddassir Awan\nReason: I approve this document\nSigned at: 2020-02-20 16:55:20 +05:00");
        appearanceCanvas.Add(text);
        signatureImage.ScaleToFit(rotatedRect.GetWidth(), 40);
        appearanceCanvas.Add(signatureImage);
        int estimatedSize = 12000;
        pdfSigner.SignExternalContainer(new ExternalBlankSignatureContainer(PdfName.Adobe_PPKLite, PdfName.Adbe_pkcs7_detached), estimatedSize);
    }
