    public static void Common_PassWordProtectPDF_Static_WithoutEmail(FileInfo[] filteredfiles, string strAgentName, string strAgentCode, string strpassword, string strEmailID, string sourcefolder, string strdestfolder, string strdestinationFileName)
    {
        foreach (FileInfo file in filteredfiles)
        {
            //string sourcePdf = Convert.ToString(ConfigurationManager.AppSettings["SourceFolder"]) + "\\" + file.Name;
            //string strdestPdf = Convert.ToString(ConfigurationManager.AppSettings["DestinationFolder"]) + file.Name;
        string sourcePdf = sourcefolder + "\\" + file.Name;
        string strdestPdf = strdestfolder + strdestinationFileName;
        using (Stream input = new FileStream(sourcePdf, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            //sourcePdf  unsecured PDF file
            //destPdf secured PDF file
            using (Stream output = new FileStream(strdestPdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfReader pdfReader = new PdfReader(input);
                X509Store store = new X509Store("My");
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2 cert = new X509Certificate2();
                RSACryptoServiceProvider csp = null;
                AcroFields fields = pdfReader.AcroFields;
                foreach (X509Certificate2 mCert in store.Certificates)
                {
                    //TODO's
                    string strresult = mCert.GetName();
                    bool str123 = false;
                    if (strresult.Contains("ANUP MADHUSUDANLAL CHANDAK") == true)
                    {
                        csp = (RSACryptoServiceProvider)mCert.PrivateKey;
                        SHA1Managed sha1 = new SHA1Managed();
                        UnicodeEncoding encoding = new UnicodeEncoding();
                        byte[] data = encoding.GetBytes(file.Name);
                        byte[] hash = sha1.ComputeHash(data);
                        // Sign the hash
                        byte[] signature = csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
                        if (Verify(file.Name, signature, mCert))
                        {
                            char s = pdfReader.PdfVersion;
                            //var pdfStamper = PdfStamper.(pdfReader, output, s, @"\0", true);
                            //csp.SignData(signature, true);
                            pdfReader.Appendable = false;
                            Org.BouncyCastle.X509.X509CertificateParser cp = new Org.BouncyCastle.X509.X509CertificateParser();
                            Org.BouncyCastle.X509.X509Certificate[] chain = new Org.BouncyCastle.X509.X509Certificate[] {
        cp.ReadCertificate(mCert.RawData)};
                            IExternalSignature externalSignature = new X509Certificate2Signature(mCert, "SHA-1");
                            // var signedPdf = new FileStream(output, FileMode.Create);
                            // var signedPdf = PdfEncryptor.Encrypt(pdfReader, output, true, strpassword, strpassword, PdfWriter.ALLOW_PRINTING);
                            //char s = pdfReader.PdfVersion;
                            var pdfStamper = PdfStamper.CreateSignature(pdfReader, output, s, @"\", false);
                            PdfSignatureAppearance signatureAppearance = pdfStamper.SignatureAppearance;
                            byte[] USER = Encoding.ASCII.GetBytes("userpwd");
                            byte[] OWNER = Encoding.ASCII.GetBytes(strpassword);
                            Rectangle cropBox = pdfReader.GetCropBox(1);
                            float width = 108;
                            float height = 32;
                            // signatureAppearance.SignatureGraphic = Image.GetInstance("C:\\logo.png");
                            //signatureAppearance.Layer4Text = "document certified by";
                            //signatureAppearance.Reason = "Because I can";
                            //signatureAppearance.Location = "My location";
                            //signatureAppearance.SetVisibleSignature(new Rectangle(100, 100, 250, 150), pdfReader.NumberOfPages, "Signature");
                            Rectangle rect = new Rectangle(600, 100, 300, 150);
                            Chunk c = new Chunk("A chunk represents an isolated string. ");
                            rect.Chunks.Add(c);
                            //signatureAppearance.SetVisibleSignature(new Rectangle(100, 100, 600, 150), pdfReader.NumberOfPages, "Signature");
                            signatureAppearance.SetVisibleSignature(rect, pdfReader.NumberOfPages, "Signature");
                            // signatureAppearance.SetVisibleSignature(new Rectangle(cropBox.GetLeft(0), cropBox.GetBottom(0), cropBox.GetLeft(width), cropBox.GetLeft(height)), pdfReader.NumberOfPages, "Signature");
                            signatureAppearance.SignatureRenderingMode = PdfSignatureAppearance.RenderingMode.DESCRIPTION;
                            pdfStamper.SetEncryption(USER, OWNER, PdfWriter.AllowPrinting, PdfWriter.ENCRYPTION_AES_128);
                            MakeSignature.SignDetached(signatureAppearance, externalSignature, chain, null, null, null, 0, CryptoStandard.CMS);
                            pdfStamper.Close();
                            // PdfEncryptor.Encrypt(pdfReader, output, true, strpassword, strpassword, PdfWriter.SIGNATURE_EXISTS);
                        }
                        else
                        {
                            Console.WriteLine("ERROR: Signature not valid!");
                        }
                    }
                }
                string Password = strpassword;
            }
        }
    }
    public static byte[] Sign(string text, string certSubject)
    {
        // Access Personal (MY) certificate store of current user
        X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
        my.Open(OpenFlags.ReadOnly);
        // Find the certificate we’ll use to sign
        RSACryptoServiceProvider csp = null;
        foreach (X509Certificate2 cert in my.Certificates)
        {
            if (cert.Subject.Contains(certSubject))
            {
                // We found it.
                // Get its associated CSP and private key
                csp = (RSACryptoServiceProvider)cert.PrivateKey;
            }
        }
        if (csp == null)
        {
            throw new Exception("No valid cert was found");
        }
        // Hash the data
        SHA1Managed sha1 = new SHA1Managed();
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] data = encoding.GetBytes(text);
        byte[] hash = sha1.ComputeHash(data);
        // Sign the hash
        return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
    }
        static bool Verify(string text, byte[] signature, X509Certificate2 cert)
        {
            // Load the certificate we’ll use to verify the signature from a file
            //  X509Certificate2 cert = new X509Certificate2(certPath);
            // Note:
            // If we want to use the client cert in an ASP.NET app, we may use something like this instead:
            // X509Certificate2 cert = new X509Certificate2(Request.ClientCertificate.Certificate);
            // Get its associated CSP and public key
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            // Hash the data
            SHA1Managed sha1 = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(text);
            byte[] hash = sha1.ComputeHash(data);
            // Verify the signature with the hash
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
    }
