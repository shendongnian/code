    private void Client_ValidateCertificate(FtpClient control, FtpSslValidationEventArgs e)
    {            
        if (e.PolicyErrors == SslPolicyErrors.None || e.Certificate.GetRawCertDataString() == "Use this condition for your situation")
        {
            e.Accept = true;
        }
        else
        {
            if (e.PolicyErrors == SslPolicyErrors.RemoteCertificateChainErrors)
            {
                //In this case, you need to choose connect or not. If your certificate file doen't have root chain.
            }
            else
            {
                //throw new Exception($"{e.PolicyErrors}{Environment.NewLine}{GetCertificateDetails(e.Certificate)}");
            }
        }
    }
