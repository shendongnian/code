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
                            //pdfReader.Appendable = true;
                            //PdfEncryptor.Encrypt(pdfReader, output, true, Password, Password, PdfWriter.ALLOW_PRINTING);
                            // PdfEncryptor.Encrypt(pdfReader, input, true, Password, Password, PdfWriter.ALLOW_PRINTING);
                            //PdfEncryptor.Encrypt(pdfReader, output, true, Password, Password, PdfWriter.ALLOW_SCREENREADERS);
                        }
                    }
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
