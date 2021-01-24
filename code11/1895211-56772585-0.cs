     X509RawDataKeyIdentifierClause keyIdentifier = metadata.RoleDescriptors.First().Keys.First().KeyInfo[0] as X509RawDataKeyIdentifierClause;
     if ( keyIdentifier != null )
     {
          X509Certificate2 cert = new X509Certificate2(keyIdentifier.GetX509RawData());
          string thumbprint     = cert.Thumbprint;
     }
