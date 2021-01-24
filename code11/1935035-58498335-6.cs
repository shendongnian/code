        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.ASCII.GetBytes(plainText);
            var 1base64 = System.Convert.ToBase64String(plainTextBytes);
            var 2base64 = System.Text.Encoding.ASCII.GetBytes(1base64);
            return System.Convert.ToBase64String(2base64); //This is the double encryption :)
        }
