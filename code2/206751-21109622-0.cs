        internal static string GetStringSha1Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;
            System.Security.Cryptography.SHA1Managed alg = new System.Security.Cryptography.SHA1Managed();
            byte[] textData = Encoding.UTF8.GetBytes(text);
            byte[] hash = alg.ComputeHash(textData);
            return BitConverter.ToString(hash).Replace("-", String.Empty);
        }
