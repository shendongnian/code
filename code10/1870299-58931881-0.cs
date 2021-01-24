    builder.Services.AddHttpClient("HttpClientWithSSLCustom).ConfigurePrimaryHttpMessageHandler(() =>
                new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) =>
                        {
                            if (policyErrors == SslPolicyErrors.None)
                            {
                                return true;
                            }
                            var validCertificate = GetCertThumbprint("Thumbnail from config maybe")
                            var passedCert = new X509Certificate2(cert);
                            return validCertificate.Equals(passedCert);
                        }
                });
