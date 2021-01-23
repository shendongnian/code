        var client
                = new SmtpClient(SmtpHostname)
                  {
                      DeliveryMethod = SmtpDeliveryMethod.Network,
                      Credentials = CredentialCache.DefaultNetworkCredentials
                  };
