        private X509Certificate2 buildSelfSignedServerCertificate(string CertificateName,string password,string dns)
        {
          
            SubjectAlternativeNameBuilder sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddIpAddress(IPAddress.Loopback);
            sanBuilder.AddIpAddress(IPAddress.IPv6Loopback);
            if (!string.IsNullOrEmpty(dns))
            {
                sanBuilder.AddDnsName(dns);
            }
          // 
          //  sanBuilder.AddDnsName(Environment.MachineName);
            X500DistinguishedName distinguishedName = new X500DistinguishedName($"CN={CertificateName}");
            using (RSA rsa = new RSACryptoServiceProvider(2048 * 2, new CspParameters(24, "Microsoft Enhanced RSA and AES Cryptographic Provider", Guid.NewGuid().ToString())))
            {
               
                var request = new CertificateRequest(distinguishedName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                
                //request.CertificateExtensions.Add(
                //    new X509KeyUsageExtension(X509KeyUsageFlags.DataEncipherment | X509KeyUsageFlags.KeyEncipherment | X509KeyUsageFlags.DigitalSignature, false));
                //request.CertificateExtensions.Add(
                //   new X509EnhancedKeyUsageExtension(
                //       new OidCollection { new Oid("1.3.6.1.5.5.7.3.1"), new Oid("1.3.6.1.5.5.7.3.2") }, false));
                request.CertificateExtensions.Add(sanBuilder.Build());
                var certificate = request.CreateSelfSigned(new DateTimeOffset(DateTime.UtcNow.AddDays(-1)), new DateTimeOffset(DateTime.UtcNow.AddDays(3650)));
                 bool isWindows = System.Runtime.InteropServices.RuntimeInformation
                               .IsOSPlatform(OSPlatform.Windows);
                if(isWindows)
                    certificate.FriendlyName = CertificateName;
                return certificate;
               // return new X509Certificate2(certificate.Export(X509ContentType.Pfx, password), password, X509KeyStorageFlags.MachineKeySet);
            }
        }
