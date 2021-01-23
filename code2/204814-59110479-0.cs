    signedXml.LoadXml((XmlElement)nodeList[0]);
            X509Certificate2 serviceCertificate = null;
            foreach (KeyInfoClause clause in signedXml.KeyInfo)
            {
                if (clause is KeyInfoX509Data)
                {
                    if (((KeyInfoX509Data)clause).Certificates.Count > 0)
                    {
                        serviceCertificate = (X509Certificate2)((KeyInfoX509Data)clause).Certificates[0];
                    }
                }
            }
