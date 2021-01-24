    ldapConnection.SessionOptions.VerifyServerCertificate =
        new VerifyServerCertificateCallback(
            (conn, certificate) =>
                {
                    X509Chain x509Chain = new X509Chain();
                    x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                    X509Certificate2 cert2 = new X509Certificate2(certificate);
                    bool buildResult = x509Chain.Build(cert2);
                    if (!buildResult)
                    {
                        foreach (X509ChainStatus chainStatus in x509Chain.ChainStatus)
                        {
                            System.Diagnostics.Debug.WriteLine(
                                String.Format(
                                    "Chain Status {0} : {1}", chainStatus.Status, chainStatus.StatusInformation));
                        }
                    }
                    return buildResult;
                });
