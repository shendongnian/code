    public static void Encrypt(XmlDocument Doc, string ElementToEncrypt, string EncryptionElementID, string Keyname)
        {
            if (Doc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("Element to Encrypt");
            if (EncryptionElementID == null)
                throw new ArgumentNullException("EncryptionElementID");
            // Create a CspParameters object and specify the name of the key container.
            var cspParams = new CspParameters { KeyContainerName = Keyname }; //"XML_RSA_FTP_KEY"
            // Create a new RSA key and save it in the container.  This key will encrypt 
            // a symmetric key, which will then be encryped in the XML document.
            var rsaAlg = new RSACryptoServiceProvider(cspParams);
            
            //specify which xml elements to encrypt
            XmlElement elementToEncrypt = Doc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;
            if (elementToEncrypt == null)
                throw new XmlException("The specified element was not found");
            try
            {
                //create session key
                RijndaelManaged sessionkey = new RijndaelManaged();
                sessionkey.KeySize = 256;
                //encrypt using Encrypted exml object and hold in byte array
                EncryptedXml exml = new EncryptedXml();
                byte[] encryptedElement = exml.EncryptData(elementToEncrypt, sessionkey, false);
                //Construct an EncryptedData object and populate
                // it with the desired encryption information.
                EncryptedData edElement = new EncryptedData();
                edElement.Type = EncryptedXml.XmlEncElementUrl;
                edElement.Id = EncryptionElementID;
                edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
                //encrypt the session key and add it encrypted key element
                EncryptedKey ek = new EncryptedKey();
                byte[] encryptedKey = EncryptedXml.EncryptKey(sessionkey.Key, rsaAlg, false);
                ek.CipherData = new CipherData(encryptedKey);
                ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
                // Create a new DataReference element
                // for the KeyInfo element.  This optional
                // element specifies which EncryptedData
                // uses this key.  An XML document can have
                // multiple EncryptedData elements that use
                // different keys.
                DataReference dRef = new DataReference();
                // Specify the EncryptedData URI.
                dRef.Uri = "#" + EncryptionElementID;
                //add data reference to encrypted key
                ek.AddReference(dRef);
                //Add the encrypted key to the
                // EncryptedData object.
                edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
                // Save some more information about the key using the EncryptionProperty element.
                // Create a new "EncryptionProperty" XmlElement object. 
                var property = new XmlDocument().CreateElement("EncryptionProperty", EncryptedXml.XmlEncNamespaceUrl);
                // Set the value of the EncryptionProperty" XmlElement object.
                property.InnerText = RijndaelManagedEncryption.EncryptRijndael(Convert.ToBase64String(rsaAlg.ExportCspBlob(true)),
                                "Your Salt string here");
                // Create the EncryptionProperty object using the XmlElement object. 
                var encProperty = new EncryptionProperty(property);
                // Add the EncryptionProperty object to the EncryptedKey object.
                ek.AddProperty(encProperty);
                // Create a new KeyInfoName element.
                KeyInfoName kin = new KeyInfoName();
                // Add the KeyInfoName element to the
                // EncryptedKey object.
                ek.KeyInfo.AddClause(kin);
                // Add the encrypted element data to the
                // EncryptedData object.
                edElement.CipherData.CipherValue = encryptedElement;
                ////////////////////////////////////////////////////
                // Replace the element from the original XmlDocument
                // object with the EncryptedData element.
                ////////////////////////////////////////////////////
                EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public static string Decrypt()
        {
            //create XML documentobject and load config file
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load("config.xml");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            //create container for key
            CspParameters cspParam = new CspParameters();
            cspParam.KeyContainerName = "XML_RSA_FTP_KEY";
            cspParam.Flags = CspProviderFlags.UseMachineKeyStore;
            //create key and store in container
            RSACryptoServiceProvider ftpkey = new RSACryptoServiceProvider(cspParam);
            var keyInfo = xmlDoc.GetElementsByTagName("EncryptionProperty")[0].InnerText;
            ftpkey.ImportCspBlob(
                Convert.FromBase64String(RijndaelManagedEncryption.DecryptRijndael(keyInfo,
                    "Your Salt string here")));
            //add keyname mapping qnd decrypt the document
            EncryptedXml exml = new EncryptedXml(xmlDoc);
            exml.AddKeyNameMapping("ftpkey", ftpkey);
            exml.DecryptDocument();
            //pass decrypted document to extract credentials method
            string details = Extract_Credentials(xmlDoc);
            //return decrypted log in details
            return details;
        }
