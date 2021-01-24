public static RSAParameters GetRSAParametersFromPublicKey(string publicKeyString)
{
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
                    // both modulus and public exponent start with 0x02: integer
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
and here is a function that encrypt the input plainText with input base64 encoded public key string
    public static string Cryptography(string plainText, string publicKeyStringBase64)
    {
        var publicKey = Convert.FromBase64String(publicKeyStringBase64);
        var publicKeyRaw = Encoding.UTF8.GetString(publicKey);
        var rsaInfo = GetRSAParametersFromPublicKey(publicKeyRaw);
        if (rsaInfo.Modulus != null && rsaInfo.Exponent != null)
        {
            var csp = new RSACryptoServiceProvider();
            csp.ImportParameters(rsaInfo);
            var hash = csp.Encrypt(Encoding.Unicode.GetBytes(plainText), false);
            var encryptedText = HttpUtility.UrlEncode(Convert.ToBase64String(hash));
          
            return encryptedText;
        }
        return "!!error!!";
    }
 4. On the server, I'd like to use phpseclib instead to generate a PKCS#1 key pair and perform the decoding (laravel):
    use phpseclib\Crypt\RSA;
    public function decryptRSATest(Request $request)
    {
        if ($request->session()->has('privkey')) 
        {
            $privkeybase64 = $request->session()->get('privkey', 'default value');
            str_replace(['\/', '\n'], ['/', ''], $privkeybase64);
            $privkey = base64_decode($privkeybase64);
            $rsa = new RSA();
            $received = str_replace(['\/', '\n',"\0",'\\'], ['/', '', '',""], $request->encrypted_text);
            $rsa->loadKey($privkey);
            $rsa->setEncryptionMode(RSA::ENCRYPTION_PKCS1);
            $decrypt_text2 = $rsa->decrypt(base64_decode($received));
            $decrypt_text2 = str_replace("\0",'',$decrypt_text2);
            return response()->json(
                [
                     'decoded_text_from_clit' => $decrypt_text2
                ]
            );
        }
        return response()->json(["error"=>"private key does not exist!"]);
    }
Moreover, if we just need the modulus and the exponent instead of a complete public key, we can just pass the modulus and exponent to the client (base64_encoded):
            // PHP - Server end
            $modulus_base64 = base64_encode($rsa->modulus);
            $exponent_base64 = base64_encode($rsa->exponent);
and in the C#, it might be a little bit tough to correctly decode them, here is a code snippet:
        // C# - Client end
        var modulus = Convert.FromBase64String(modulusStringBase64);
        var exponent = Convert.FromBase64String(exponentStringBase64);
        var modulusRaw = Encoding.UTF8.GetString(modulus);
        var exponentRaw = Encoding.UTF8.GetString(exponent);
        var bigIntegerModulus = BigInteger.Parse(modulusRaw);
        var bigIntegerExponent = BigInteger.Parse(exponentRaw);
        var exponentArray = bigIntegerExponent.ToByteArray();
        var modulusArray = bigIntegerModulus.ToByteArray();
and some useful online tools:
[base64 decoder][2]
[ASN 1 decoder][3]
[Json Viewer][4]
Hope this could be helpful for you.
  [1]: https://stackoverflow.com/questions/41808094/correctly-create-rsacryptoserviceprovider-from-public-key
  [2]: https://www.base64decode.net/
  [3]: https://lapo.it/asn1js/
  [4]: https://codebeautify.org/jsonviewer
