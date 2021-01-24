    using (PdfReader pdfReader = new PdfReader(SRC))
    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(DEST, FileMode.Create, FileAccess.Write), '\0', true))
    {
        AcroFields acroFields = pdfStamper.AcroFields;
        foreach (String signatureName in acroFields.GetSignatureNames())
        {
            PdfPKCS7 pkcs7 = acroFields.VerifySignature(signatureName);
            X509Certificate signerCert = pkcs7.SigningCertificate;
            String signerName = CertificateInfo.GetSubjectFields(signerCert).GetField("CN");
            AcroFields.Item field = acroFields.GetFieldItem(signatureName);
            for (int i = 0; i < field.Size; i++)
            {
                PdfDictionary widget = field.GetWidget(i);
                Rectangle rect = PdfReader.GetNormalizedRectangle(widget.GetAsArray(PdfName.RECT));
                PdfAppearance appearance = PdfAppearance.CreateAppearance(pdfStamper.Writer, rect.Width, rect.Height);
                ColumnText columnText = new ColumnText(appearance);
                Chunk chunk = new Chunk();
                chunk.SetSkew(0, 12);
                chunk.Append("Signed by:");
                columnText.AddElement(new Paragraph(chunk));
                chunk = new Chunk();
                chunk.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 1, BaseColor.BLACK);
                chunk.Append(signerName);
                columnText.AddElement(new Paragraph(chunk));
                columnText.SetSimpleColumn(0, 0, rect.Width, rect.Height - 15);
                columnText.Go();
                PdfDictionary xObjects = GetAsDictAndMarkUsed((PdfStamperImp)pdfStamper.Writer, widget, PdfName.AP, PdfName.N, PdfName.RESOURCES, PdfName.XOBJECT, PdfName.FRM, PdfName.RESOURCES, PdfName.XOBJECT);
                xObjects.Put(PdfName.N2, appearance.IndirectReference);
            }
        }
    }
