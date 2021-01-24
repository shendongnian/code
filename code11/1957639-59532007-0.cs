      X509Certificate2 cert = null;
      X509Store x509Store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
      x509Store.Open(OpenFlags.ReadWrite);
       //manually chose the certificate in the store
      Selectcert: X509Certificate2Collection select = X509Certificate2UI.SelectFromCollection(x509Store.Certificates, null, null, X509SelectionFlag.SingleSelection);
       if (select.Count > 0)
       cert = select[0]; //This will get us the selected certificate in "cert" object
    foreach (System.Security.Cryptography.X509Certificates.X509Extension extension in cert.Extensions)
                    {
                        if (extension.Oid.Value == "1.2.840.113583.1.1.9.1")
                        {
                            var ext = extension;
                            AsnEncodedData asndata = new AsnEncodedData(extension.Oid, extension.RawData);
                            var rawdata = asndata.RawData;
                            var val = Encoding.Default.GetString(rawdata);
                            var timestampUrl = TrimNonAscii(val);
                            timestampUrl = timestampUrl.Substring(timestampUrl.IndexOf("http"));
                        }
                    }
