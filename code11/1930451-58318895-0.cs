        static async Task Main(string[] args)
        {
            var data = new ServiceReference1.Service1Client(Service1Client.EndpointConfiguration.BasicHttpsBinding_IService1);
            data.Endpoint.Address = new EndpointAddress("https://localhost:5035/Service1.svc");
            (data.Endpoint.Binding as BasicHttpBinding).Security.Mode = BasicHttpSecurityMode.Transport;
            data.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new X509ServiceCertificateAuthentication();
            data.ClientCredentials.ServiceCertificate.SslCertificateAuthentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            data.ClientCredentials.ServiceCertificate.SslCertificateAuthentication.CustomCertificateValidator = new Validator();
            var result = await data.GetDataAsync(1);
            Console.WriteLine(result);
        }
And there is validator:
    internal class Validator : X509CertificateValidator
    {
        public override void Validate(X509Certificate2 certificate)
        {
            X509Chain chain = new X509Chain();
            if (!chain.Build(certificate))
            {
                Console.WriteLine($"{chain.ChainStatus.FirstOrDefault().StatusInformation}. Press y to proceed...");
                if(Console.ReadKey().KeyChar != 'y')
                    throw new SecurityTokenValidationException("Service certification is not valid.");
            }
        }
    }
