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
                    {
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
