        private XmlDocument GetSignedDoc(XmlDocument doc)
    {
          X509Certificate2 certificate = null;
                        try
                        {
                            certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + licenceFile, licenceFilePass, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);
                           
                            if (certificate == null)
                                throw new Exception("The certificate i
    
    s null!!!");
                    }
                    catch (Exception ex)
                    {
                        exception += "X509Certificate2 fail! Did not get certificate " + AppDomain.CurrentDomain.BaseDirectory + licenceFile;
                        exception += FormatException(ex);
                        goto SetError;
                    }
                RSACryptoServiceProvider myRSASigner = null;
                
                try
                {
                    myRSASigner = (RSACryptoServiceProvider)certificate.PrivateKey;
                    if (myRSASigner == null)
                    {
                        throw new Exception("No valid cert was found");
                    }
                   
                        doc = SignXmlFile(doc, myRSASigner);
                   
               catch (Exception ex)
                    {
                        exception += "SignXmlFile failed";
                        exception += FormatException(ex);
                        goto SetError;
                    }
}
    private static XmlDocument SignXmlFile(XmlDocument doc, RSACryptoServiceProvider myRSA)
                {
                    byte[] sign_this = Encoding.UTF8.GetBytes(doc.InnerXml);
                    byte[] signature = myRSA.SignData(sign_this, new SHA1CryptoServiceProvider());
                    string base64_string = Convert.ToBase64String(signature);
        
                    XmlElement Signature = doc.CreateElement("Signature");
                    Signature.AppendChild(doc.CreateTextNode(base64_string));
                    doc.DocumentElement.AppendChild(doc.ImportNode(Signature, true));
        
                    return doc;
                }
