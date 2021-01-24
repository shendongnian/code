        internal string FormatPassword(string password)
        {
            string formattedPassword = string.Empty;
            for (int pos = 0; pos < password.Length; pos+=2)
            {
                string partialPassword = string.Empty;
                if (password.Length > pos + 1)
                {
                    partialPassword = GetPasswordByte(password.Substring(pos, 2));
                }
                else
                {
                    partialPassword = GetPasswordByte(password.Substring(pos, 1));
                }
                if (!string.IsNullOrEmpty(partialPassword))
                {
                    formattedPassword += partialPassword;
                }
            }
            if (formattedPassword.Length < 8)
            {
                formattedPassword = formattedPassword.PadRight(8, (char)0xFF);
            }
            return formattedPassword;
        }
        internal string GetPasswordByte(string partialPassword)
        {
            string byteString = string.Empty;
            int digit1 = Convert.ToInt16(partialPassword.Substring(0, 1));
            int digit2 = 15;
            if (partialPassword.Length > 1)
            {
                digit2 = Convert.ToInt16(partialPassword.Substring(1, 1));
            }
            byte[] passwordByte = BitConverter.GetBytes((digit1 << 4) | (digit2 & 0xF));
            byteString = System.Text.Encoding.Default.GetString(passwordByte, 0, 1);
            return byteString;
        }
