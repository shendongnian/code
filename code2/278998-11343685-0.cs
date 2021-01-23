I'm not sure that the solution you provide is actually a valid solution for the problem. Also, some of your comments regarding HttpWebRequest.ClientCertificates indicate this.
First, it is important to distinguish between the server validating a client certificate and the client validating a server certificate. Collection HttpWebRequest.ClientCertificates is used to send client certificates to the server, so the server can validate who the client is. Your question (as far as I understand it) was how server certificate which does not pass the default validation (such as a self-signed cert) can be validated against a certificate locally stored at the client.
In this case a solution is indeed to use System.Net.ServicePointManager.ServerCertificateValidationCallback and provide a custom validation. However, your validation method seems wrong: it verifies the local certificate and does not care about the cert send by the server. What I'd use is something like this:
    public static bool customXertificateValidation(
        Object sender, X509Certificate certificate, 
        X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        return clientCert.Equals(certificate);
    };
