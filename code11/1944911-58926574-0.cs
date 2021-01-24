            // publicKeyString should have following format:
            // -----BEGIN RSA PUBLIC KEY---- -
            // base64 encoded data
            // -----END RSA PUBLIC KEY---- -
            var pubicKeyContentString = publicKeyString.Replace("-----BEGIN RSA PUBLIC KEY-----", "")
                .Replace("-----END RSA PUBLIC KEY-----", "")
                .Replace("\r", "")
                .Replace("\n", "")
                .Replace(@"\/", "/");
            var publicKeyArray = Convert.FromBase64String(pubicKeyContentString);
            var mask = 0x7F;
            var skipCount = 0;
            var rsaParameters = new RSAParameters();
            for (int i = 0; i < publicKeyArray.Length; i=skipCount)
            {
                var tag = publicKeyArray[i];
                var lengthLength = publicKeyArray[i + 1];
                var length = Convert.ToInt32(lengthLength);
                skipCount += 2;
                if (lengthLength > mask)
                {
                    var lengthBit = lengthLength & mask;
                    var lengthBytes = publicKeyArray.Skip(skipCount).Take(lengthBit).ToArray();
                    skipCount += lengthBit;
                    length = BitConverter.ToInt16(lengthBytes.Reverse().ToArray(),0);
                }
                if (tag == 0x02)
                {
                    // both modulus and public exponent are starts with 0x02: integer
                    // therefore, 0x02 is the only tag we are interested in
                    var valueBytes = publicKeyArray.Skip(skipCount).Take(length).ToArray();
                    if (valueBytes[0] == 0x00)
                    {
                        // a valid DER has a leading byte 0x00
                        rsaParameters.Modulus = valueBytes.Skip(1).ToArray();
                    }
                    else
                    {
                        rsaParameters.Exponent = valueBytes;
                    }
                    skipCount += length;
                }
            }
            return rsaParameters;
        }
