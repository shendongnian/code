    using (PdfReader pdfReader = new PdfReader(SRC))
    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(DEST, FileMode.Create, FileAccess.Write), '\0', true))
    {
        AcroFields acroFields = pdfStamper.AcroFields;
        foreach (String signatureName in acroFields.GetSignatureNames())
        {
            PdfPKCS7 pkcs7 = acroFields.VerifySignature(signatureName);
            X509Certificate signerCert = pkcs7.SigningCertificate;
            String signerName = CertificateInfo.GetSubjectFields(signerCert).GetField("CN");
            PdfAppearance appearance = PdfAppearance.CreateAppearance(pdfStamper.Writer, 100, 100);
            ColumnText columnText = new ColumnText(appearance);
            Chunk chunk = new Chunk();
            chunk.SetSkew(0, 12);
            chunk.Append("Signed by:");
            columnText.AddElement(new Paragraph(chunk));
            chunk = new Chunk();
            chunk.SetTextRenderMode(PdfContentByte.TEXT_RENDER_MODE_FILL_STROKE, 1, BaseColor.BLACK);
            chunk.Append(signerName);
            columnText.AddElement(new Paragraph(chunk));
            columnText.SetSimpleColumn(0, 0, 100, 100);
            columnText.Go();
            PdfDictionary appDict = new PdfDictionary();
            appDict.Put(PdfName.N, appearance.IndirectReference);
            AcroFields.Item field = acroFields.GetFieldItem(signatureName);
            for (int i = 0; i < field.Size; i++)
            {
                PdfDictionary widget = field.GetWidget(i);
                PdfArray rect = widget.GetAsArray(PdfName.RECT);
                float x = Math.Min(rect.GetAsNumber(0).FloatValue, rect.GetAsNumber(0).FloatValue);
                float y = Math.Min(rect.GetAsNumber(1).FloatValue, rect.GetAsNumber(3).FloatValue);
                widget.Put(PdfName.RECT, new PdfArray(new float[] { x, y, x + 100, y + 100 }));
            }
            field.WriteToAll(PdfName.AP, appDict, AcroFields.Item.WRITE_WIDGET);
            field.MarkUsed(acroFields, AcroFields.Item.WRITE_WIDGET);
        }
    }
