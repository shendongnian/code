     private X509Certificate2 GetCertificate()
        {
            var certStore = new X509Store("my");
            certStore.Open(OpenFlags.ReadOnly);
            try
            {
                const string thumbprint = "18 33 fe 3a 67 d1 9e 0d f6 1e e5 d5 58 aa 8a 97 8c c4 d8 c3";
                var certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint,
                Regex.Replace(thumbprint, @"\s+", "").ToUpper(), false);
                if (certCollection.Count > 0)
                    return certCollection[0];
            }
            finally
            {
                certStore.Close();
            }
            return null;
        }
