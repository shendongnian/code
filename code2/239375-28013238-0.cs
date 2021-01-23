            string digitsOnly = String.Empty;
            foreach (char c in s)
            {
                // Do not use IsDigit as it will include more than the characters 0 through to 9
                if (c >= '0' && c <= '9') digitsOnly += c;
            }
