        public int CountDecimalDigits(string value)
        {
            char[] possibleChars = "0123456789.".ToCharArray();
            int decimalPoints = 0;
            foreach (char ch in value)
            {
                if (Array.IndexOf(possibleChars, ch) < 0)
                    throw new Exception();
                if (ch == '.') decimalPoints++;
            }
            if (decimalPoints > 1)
                throw new Exception();
            if (decimalPoints == 0) return 0;
            return value.Length - value.IndexOf('.') - 1;
        }
