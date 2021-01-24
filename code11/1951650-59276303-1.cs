        private static ECDsa LoadPublicKey(byte[] key)
        {
            byte[] pubKeyX = key.Skip(1).Take(45).ToArray();
            byte[] pubKeyY = key.Skip(46).ToArray();
            return ECDsa.Create(new ECParameters
            {
                Curve = ECCurve.NamedCurves.nistP256,
                Q = new ECPoint
                {
                    X = pubKeyX,
                    Y = pubKeyY
                }
            });
        }
---------------
            string key = "MFkwEwYHKoZIzj0CAQYIKoZIzj0DAQcDQgAENARdEGaEpfgHph3440UodVsQdqxiPYz+l1aEcz+Bivr6emXDnor1nET94dbPqYxk+vtUHGkgOb44VPEZUe4ijQ==";
            ECDsa ecdsa = LoadPublicKey(Convert.FromBase64String(key));
            string authorizationDomain = "https://siemens-qa-00069.eu.auth0.com/";
            string jwt = "eyJ0eXAiOiJKV1QiLCJraWQiOiJjODE4ZTcxNi01OTAxLTQzOWQtOWFlZC1lYmRmODAyYjZkYTkiLCJhbGciOiJFUzI1NiIsImlzcyI6Imh0dHBzOi8vc2llbWVucy1xYS0wMDA2OS5ldS5hdXRoMC5jb20vIiwiY2xpZW50IjoiMndsS3k0YlRXbGpZWm9KYXZRSVFqVTE3OUprVG4zNDAiLCJzaWduZXIiOiJhcm46YXdzOmVsYXN0aWNsb2FkYmFsYW5jaW5nOmV1LWNlbnRyYWwtMTo0ODU2ODM0ODcxOTY6bG9hZGJhbGFuY2VyL2FwcC9maW5kLXRlc3QtYWxiLzU3YzBmMWYzZjg0YzZjMjEiLCJleHAiOjE1NzU1NDMwMzN9.eyJzdWIiOiJvYXV0aDJ8bWFpbi10ZW5hbnQtb2lkY3xzYW1scHxTaWVtZW5zfFowMDJFSk5VIiwiZ2l2ZW5fbmFtZSI6IlJhcGhhZWwiLCJmYW1pbHlfbmFtZSI6IlNjaG5haXRsIiwibmlja25hbWUiOiJSYXBoYWVsIiwibmFtZSI6IlJhcGhhZWwgU2NobmFpdGwiLCJwaWN0dXJlIjoiaHR0cHM6Ly9zLmdyYXZhdGFyLmNvbS9hdmF0YXIvODkzNWVlY2QzMDc2ZTAyMTQ5ODE2MTZmZjBkZTRkZjI_cz00ODAmcj1wZyZkPWh0dHBzJTNBJTJGJTJGY2RuLmF1dGgwLmNvbSUyRmF2YXRhcnMlMkZyYS5wbmciLCJ1cGRhdGVkX2F0IjoiMjAxOS0xMi0wNVQxMDo0ODozMy4wNjhaIiwiZXhwIjoxNTc1NTQzMDMzLCJpc3MiOiJodHRwczovL3NpZW1lbnMtcWEtMDAwNjkuZXUuYXV0aDAuY29tLyJ9.M39aPefXmaDGzaDd0qHcQHMhvugTVN4i4pyvGJ-7fayewU9vZdtKvSzFF9rVal8GEz7HKTr_auqMw9HemOWyag==";
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = authorizationDomain,
                ValidateAudience = false,
                IssuerSigningKey = new ECDsaSecurityKey(ecdsa)
            };
            try
            {
                JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
                jwtSecurityTokenHandler.ValidateToken(jwt, tokenValidationParameters, out _);
                return true;
            }
            catch (SecurityTokenException)
            {
                return false;
            }
