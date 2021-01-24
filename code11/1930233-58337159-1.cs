    private async Task VerifySignature(HttpRequestMessage request)
        {
            IEnumerable<string> headers;
            const string signatureHeaderName = "ms-signature";
            string secretKey = WebConfigurationManager.AppSettings["MS_WebHookReceiverSecret_MyController"];
            if (request.Headers.TryGetValues(signatureHeaderName, out headers))
            {
                string headerValue = headers.First().Replace("sha256=", "").Trim();
                byte[] expectedHash;
                try
                {
                    expectedHash = FromHex(headerValue);
                }
                catch (Exception)
                {
                    var invalidEncoding = request.CreateErrorResponse(HttpStatusCode.BadRequest, $"HexValue '{headerValue}' received is not valid. It must be an hex string value.");
                    throw new HttpResponseException(invalidEncoding);
                }
                byte[] actualHash;
                var secret = Encoding.UTF8.GetBytes(secretKey);
                using (var hasher = new HMACSHA256(secret))
                {
                    var data = await request.Content.ReadAsByteArrayAsync();
                    actualHash = hasher.ComputeHash(data);
                }
                if (!SecretEqual(expectedHash, actualHash))
                {
                    var message = $"WebHook signature '{signatureHeaderName}' from header is not valid.";
                    var badSignature = request.CreateErrorResponse(HttpStatusCode.BadRequest, message);
                    throw new HttpResponseException(badSignature);
                }
            }
        }
        private static bool SecretEqual(byte[] inputA, byte[] inputB)
        {
            if (ReferenceEquals(inputA, inputB))
            {
                return true;
            }
            if (inputA == null || inputB == null || inputA.Length != inputB.Length)
            {
                return false;
            }
            var areSame = true;
            for (var i = 0; i < inputA.Length; i++)
            {
                areSame &= inputA[i] == inputB[i];
            }
            return areSame;
        }
        private static byte[] FromHex(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return new byte[0];
            }
            byte[] data;
            try
            {
                data = new byte[content.Length / 2];
                var input = 0;
                for (var output = 0; output < data.Length; output++)
                {
                    data[output] = Convert.ToByte(new string(new[] { content[input++], content[input++] }), 16);
                }
                if (input != content.Length)
                {
                    data = null;
                }
            }
            catch
            {
                data = null;
            }
            if (data == null)
            {
                throw new InvalidOperationException($"Value: '{content}' is not in hex. Please send an hex string.");
            }
            return data;
        }
