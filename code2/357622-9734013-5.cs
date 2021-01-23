            // rootCerts : collection of CA
            // currentCertificate : the one you want to test
            var builderParams = new PkixBuilderParameters(rootCerts, 
                                    new X509CertStoreSelector { Certificate = currentCertificate });
            // crls : The certificate revocation list
            builderParams.IsRevocationEnabled = crls.Count != 0;
            // validationDate : probably "now"
            builderParams.Date = new DateTimeObject(validationDate);
            
            // The indermediate certs are items necessary to create the certificate chain
            builderParams.AddStore(X509StoreFactory.Create("Certificate/Collection", new X509CollectionStoreParameters(intermediateCerts)));
            builderParams.AddStore(X509StoreFactory.Create("CRL/Collection", new X509CollectionStoreParameters(crls)));
            try
            {
                PkixCertPathBuilderResult result = builder.Build(builderParams);
                return result.CertPath.Certificates.Cast<X509Certificate>();
                ...
