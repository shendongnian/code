    static bool IsSpecialChar(this char c)
    {
        const string specialChars = "!@#$%^&*()_-+=[{]};:<>|./?";
        return specialChars.Contains(c);
    }
    static bool IsValidPassword(this string password)
    {
        // the password needs to be at least 8 characters,
        // contain an uppercase, lowercase, digit and a special char
        // TODO: exception if password == null;
        if (password.Length < 8) return false;
        bool uppercaseDetected = false;
        bool lowercaseDetected = false;
        bool digitDetected = false;
        bool specialCharDetected = false;
        using (IEnumerator<char> enumerator = password.GetEnumerator())
        {
            while (enumerator.MoveNext
               && !(uppercaseDetected && lowercaseDetected 
                     && digitDetected && specialCharDetected))
            {
                // a character is available, and we still don't know if it is a proper password
                char c = enumerator.Current;
                uppercaseDetected = uppercaseDetected || Char.IsUpperCase(c);
                lowercaseDetected = lowercaseDetected || Char.IsLowerCase(c);
                digitDetected = digitDetected || Char.IsDigit(c);
                specialCharDetected = specialCharDetected || c.IsSpecialChar();
            }
            return uppercaseDetected && lowercaseDetected 
                && digitDetected && specialCharDetected;
        }
    }
