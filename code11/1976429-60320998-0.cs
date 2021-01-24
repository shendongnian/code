    using (PdfReader pdfReader = new PdfReader("LTV Doc-Revocation Info Issue.pdf"))
    using (PdfWriter pdfWriter = new PdfWriter("LTV Doc-Revocation Info Issue-WithRevocation.pdf"))
    using (PdfDocument pdfDocument = new PdfDocument(pdfReader, pdfWriter, new StampingProperties().UseAppendMode()))
    {
        List<byte[]> ocspCollection = new List<byte[]>();
        List<byte[]> crlCollection = new List<byte[]>();
        List<byte[]> certsCollection = new List<byte[]>();
        ocspCollection.Add(File.ReadAllBytes(@"Ocsp"));
        crlCollection.Add(File.ReadAllBytes(@"Crl.crl"));
        LtvVerification ltvVerification = new LtvVerification(pdfDocument);
        ltvVerification.AddVerification("SH_SIGNATURE_532546", ocspCollection, crlCollection, certsCollection);
        ltvVerification.Merge();
    }
