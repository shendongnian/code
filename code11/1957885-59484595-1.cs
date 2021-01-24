    public static RsaSecurityKey PrivateKeyFromPem(string keyPairPem)
            {
                PemReader pemReader = new PemReader(new StringReader(keyPairPem));
                AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();
                RsaPrivateCrtKeyParameters privateKeyParameters = (RsaPrivateCrtKeyParameters)keyPair.Private;
                RSAParameters rsaParameters = DotNetUtilities.ToRSAParameters(privateKeyParameters);
                return new RsaSecurityKey(rsaParameters);
            }
    
       public static void Main()
        {
        var privateKey = @"-----BEGIN PRIVATE KEY----- {some string data} -----END 
                         PRIVATE KEY-----";
            DateTime now = DateTime.Now;
            var payload = new JwtPayload
        {
            { "iss", "1198bef0-a0d52731-706e-4936-be46-1ae4b2b2e9bd" },
            { "iat", now },
            { "exp", now.AddMinutes(30) }
        };
            var credentials =new SigningCredentials(
              PrivateKeyFromPem(privateKey),
              SecurityAlgorithms.RsaSha512
            );
            var header = new JwtHeader(signingCredentials: credentials);
            var jst = new JwtSecurityToken(header, payload);
            var tokenHandler = new JwtSecurityTokenHandler();
            string assertion = tokenHandler.WriteToken(jst);
            Console.WriteLine(assertion);
        }
