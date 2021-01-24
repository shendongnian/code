        string GetRandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var nonDigitChars = chars.Where(x => !char.IsDigit(x)).ToArray();
            var random = new Random();
            int numberOfDigits = 0;
            var randomChars = new char[length];
            for (int i = 0; i < randomChars.Length; i++)
            {
                char c;
                if (numberOfDigits == 2)
                {
                    //select from nonDigitChars
                    c = nonDigitChars[random.Next(nonDigitChars.Length)];
                }
                else
                {
                    c = chars[random.Next(chars.Length)];
                    if (char.IsDigit(c))
                    {
                        numberOfDigits++;
                    }
                }
                randomChars[i] = c;
            }
            return new string(randomChars);
        }
