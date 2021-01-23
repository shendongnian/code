        static X509Certificate2 GetRandomCertificate()
        {
            X509Store st = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            st.Open(OpenFlags.ReadOnly);
            try
            {
                var certCollection = st.Certificates;
                if (certCollection.Count == 0)
                {
                    return null;
                }
                return certCollection[0];
            }
            finally
            {
                st.Close();
            }
        }
