    Console.WriteLine("  with {0} CRLs\n", crl.Count);
    foreach (byte[] crlBytes in crl)
    {
        PdfName hashKey = null;
        byte[] bytes = null;
        try
        {
            hashKey = getCrlHashKey(crlBytes);
            bytes = crlBytes;
        }
        catch (Exception e)
        {
            Console.WriteLine("  CRL decoding exception, assuming Base64 encoding, trying to decode - {0}\n", e.Message);
            bytes = Convert.FromBase64String(new String(Encoding.Default.GetChars(crlBytes)));
            hashKey = getCrlHashKey(bytes);
        }
        validationData.crls.Add(bytes);
        addLtvForChain(null, ocspClient, crlClient, hashKey);
    }
