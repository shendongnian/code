// Sign an XML request and return it
public static string SignRequest(string request, string SubjectName, string Signature, string keyInfoRefId)
{
    if (string.IsNullOrEmpty(request))
        throw new ArgumentNullException("request");
    if (string.IsNullOrEmpty(SubjectName))
        throw new ArgumentNullException("SubjectName");
    // Load the certificate from the certificate store.
    X509Certificate2 cert = GetCertificateBySubject(SubjectName);
    // Create a new XML document.
    XmlDocument doc = new XmlDocument();
    // Format the document to ignore white spaces.
    doc.PreserveWhitespace = false;
    // Load the passed XML 
    doc.LoadXml(request);
    // Add the declaration as per Entrust sample provided -don't think it's necessary though
    if (!(doc.FirstChild is XmlDeclaration))
    {
        XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", string.Empty);
        doc.InsertBefore(declaration, doc.FirstChild);
    }
    // Remove the Action (MustUnderstand). 
    // TODO: Need to find a more elegant way to do so
    XmlNode headerNode = null;
    XmlNodeList nodeList = doc.GetElementsByTagName("Action");
    if (nodeList.Count > 0)
    {
        headerNode = nodeList[0].ParentNode;
        headerNode.RemoveChild(nodeList[0]);
    }
    // Set the body id - not in used but could be useful at a later stage of this project
    XmlNamespaceManager ns = new XmlNamespaceManager(doc.NameTable);    
    ns.AddNamespace("s", "http://schemas.xmlsoap.org/soap/envelope/");
    XmlElement body = doc.DocumentElement.SelectSingleNode(@"//s:Body", ns) as XmlElement;    
    if (body == null)    
        throw new ApplicationException("No body tag found");
    body.RemoveAllAttributes();  // no need to have namespace
    body.SetAttribute("Id", "ABC"); // Body Id could be passed as a param
    // Create a custom SignedXml object so that we could sign the keyinfo
    CustomSignedXml signedXml = new CustomSignedXml(doc);
    // Add the key to the SignedXml document. 
    signedXml.SigningKey = cert.PrivateKey;
    // Create a new KeyInfo object.
    KeyInfo keyInfo = new KeyInfo();
    keyInfo.Id = keyInfoRefId;
    // Load the certificate into a KeyInfoX509Data object
    // and add it to the KeyInfo object.
    KeyInfoX509Data keyInfoData = new KeyInfoX509Data();
    keyInfoData.AddCertificate(cert);
    keyInfo.AddClause(keyInfoData);
    // Add the KeyInfo object to the SignedXml object.
    signedXml.KeyInfo = keyInfo;
    // Create a reference to be signed.
    Reference reference = new Reference();
    reference.Uri = "";
    // Add an enveloped transformation to the reference.
    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
    reference.AddTransform(env);
    // Add the reference to the SignedXml object.
    signedXml.AddReference(reference);
    Reference reference2 = new Reference();
    reference2.Uri = "#" + keyInfoRefId;
    signedXml.AddReference(reference2);
    // Add the Signature Id
    signedXml.Signature.Id = Signature;
    // Compute the signature.
    signedXml.ComputeSignature();
    // Get the XML representation of the signature and save
    // it to an XmlElement object.
    XmlElement xmlDigitalSignature = signedXml.GetXml();
    // Append the Signature element to the XML document.
    if (headerNode != null)
    {                
        headerNode.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
    }
    return doc.InnerXml;
}
public static X509Certificate2 GetCertificateBySubject(string CertificateSubject)
{
    // Check the args.
    if (string.IsNullOrEmpty(CertificateSubject))
        throw new ArgumentNullException("CertificateSubject");
    // Load the certificate from the certificate store.
    X509Certificate2 cert = null;
    X509Store store = new X509Store(StoreName.My, StoreLocation.CurrentUser);
    try
    {
        // Open the store.
        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
        // Find the certificate with the specified subject.
        cert = store.Certificates.Find(X509FindType.FindBySubjectName, CertificateSubject, false)[0];
        
        // Throw an exception of the certificate was not found.
        if (cert == null)
        {
            throw new CryptographicException("The certificate could not be found.");
        }
    }
    finally
    {
        // Close the store even if an exception was thrown.
        store.Close();
    }
    return cert;
