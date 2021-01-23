      private static string GetFixedLengthStrinng(int len)
        {
            const string possibleAllChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@#$%^&*()_+{}:',.?/";
            StringBuilder sb = new StringBuilder();
            Random randomNumber = new Random();
            for (int i = 0; i < len; i++)
            {
                sb.Append(possibleAllChars[randomNumber.Next(0, possibleAllChars.Length)]);
            }
            return sb.ToString();
        }
