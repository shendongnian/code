       public void CalculateSignature()
        {
            const string secretKey = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"; // Secret signature
            byte[] actualHash;
            var secret = Encoding.UTF8.GetBytes(secretKey);
            using (var hasher = new HMACSHA256(secret))
            {
                string data = "INCLUDE HERE JSON VALUE TO SEND";
                byte[] bytes = Encoding.UTF8.GetBytes(data);
                actualHash = hasher.ComputeHash(bytes);
                string hash = Encoding.UTF8.GetString(actualHash);
                var hexString = BitConverter.ToString(actualHash);
                hexString = hexString.Replace("-", "");
            }
        }
