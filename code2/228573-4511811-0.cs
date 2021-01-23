            // Assume 'site' is already set to your site via something like 
            // Site site = mgr.Sites.Add(siteName, directory, 443);
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.OpenExistingOnly | OpenFlags.ReadWrite);
            // Here, directory is my install dir, and (directory)\bin\certificate.pfx is where the cert file is.
            // 1234 is the password to the certfile (exported from IIS)
            X509Certificate2 certificate = new X509Certificate2(directory + @"\bin\certificate.pfx", "1234");
            store.Add(certificate);
            var binding = site.Bindings.Add("*:443:", certificate.GetCertHash(), store.Name);
            binding.Protocol = "https";
            store.Close();
