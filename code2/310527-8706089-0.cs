        public static SecureString StringToSecureString(string input)
        {
            SecureString output = new SecureString();
            int l = input.Length;
            char[] s = input.ToCharArray(0, l);
            foreach (char c in s)
            {
                output.AppendChar(c);
            }
            return output;
        }
The significant issue with this code is that the developer allowed the input string to _ever_ exist in memory in the first place.  The User Control or WinForm TextBox of PasswordBox used to collect this password from the user should never collect the whole password in one operation, as 
