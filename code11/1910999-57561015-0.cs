    using (PdfReader pdfReader = new PdfReader(PDF))
    using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
    {
        SignatureUtil signatureUtil = new SignatureUtil(pdfDocument);
        foreach (string signatureName in signatureUtil.GetSignatureNames())
        {
            Console.WriteLine("\n{0}\n**********", signatureName);
            Console.WriteLine("Name: " + signatureUtil.GetSignature(signatureName).GetName());
            Console.WriteLine("Signature covers whole document: " + signatureUtil.SignatureCoversWholeDocument(signatureName));
            Console.WriteLine("Document revision: " + signatureUtil.GetRevision(signatureName) + " of " + signatureUtil.GetTotalRevisions());
            PdfPKCS7 pkcs7 = signatureUtil.ReadSignatureData(signatureName);
            Console.WriteLine("Integrity check OK? " + pkcs7.VerifySignatureIntegrityAndAuthenticity());
            Org.BouncyCastle.X509.X509Certificate cert = pkcs7.GetSigningCertificate();
            Console.Write("Subject alternative names: ");
            foreach (var list in cert.GetSubjectAlternativeNames())
                foreach (var name in (IList)list)
                    Console.Write(name + " ");
            Console.WriteLine();
            Org.BouncyCastle.Asn1.X509.X509Name subjectDn = cert.SubjectDN;
            Console.WriteLine("Subject DN: " + subjectDn);
            Console.Write("Subject DN common name: ");
            foreach (var name in subjectDn.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.CN))
                Console.Write(name + " ");
            Console.WriteLine();
            Console.Write("Subject DN email: ");
            foreach (var name in subjectDn.GetValueList(Org.BouncyCastle.Asn1.X509.X509Name.EmailAddress))
                Console.Write(name + " ");
            Console.WriteLine();
        }
    }
