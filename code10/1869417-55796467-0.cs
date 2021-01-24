        public void SignAssertion()
        {
            var xmlDoc = new XmlDocument { PreserveWhitespace = false };
            xmlDoc.Load("UnsignedAssertion.xml");
            var signedXml = new SignedXml(xmlDoc);
            signedXml.SigningKey = getCert().PrivateKey;
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
            var canMethod = (XmlDsigExcC14NTransform)signedXml.SignedInfo.CanonicalizationMethodObject;
            canMethod.InclusiveNamespacesPrefixList = "Sign";
            var transforms = new TransformChain();
            transforms.Add(new XmlDsigEnvelopedSignatureTransform());
            var reference = new Reference
            {
                Id = "#pfx96e500ef-d656-e97c-17ee-bbeff75c7235",
                TransformChain = transforms,
                Uri = "" // This is the solution...
            };
            signedXml.AddReference(reference);
            signedXml.ComputeSignature();
        }
