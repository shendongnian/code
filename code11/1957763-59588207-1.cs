    internal static class BouncyCastleTls
    {
        public static Stream WrapWithTls(Stream stream)
        {
            var client = new MyTlsClient();
            var tlsClientProtocol = new TlsClientProtocol(stream, new SecureRandom());
            tlsClientProtocol.Connect(client);
            return tlsClientProtocol.Stream;
        }
    }
    internal sealed class MyTlsClient : DefaultTlsClient
    {
        public override TlsAuthentication GetAuthentication()
        {
            return new MyTlsAuthentication();
        }
        public override void NotifyHandshakeComplete()
        {
            var clientRandom = mContext.SecurityParameters.ClientRandom;
            var masterSecret = mContext.SecurityParameters.MasterSecret;
            Console.WriteLine("CLIENT_RANDOM {0} {1}", ToHex(clientRandom), ToHex(masterSecret));
        }
        private static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            for (var i = 0; i < bytes.Length; ++i)
                sb.Append($"{bytes[i]:x2}");
            return sb.ToString();
        }
    }
    internal sealed class MyTlsAuthentication : TlsAuthentication
    {
        public void NotifyServerCertificate(Certificate serverCertificate)
        {
        }
        public TlsCredentials GetClientCredentials(CertificateRequest certificateRequest)
        {
            return null;
        }
    }
