        string passwordPre = DecryptProprietary(objectReferringToPassword);
        char[] passwordChars = passwordPre.ToCharArray();        
        System.Security.SecureString securePassword = new System.Security.SecureString(); // in production, this should probably be a global variable
        foreach (char c in passwordChars)
            securePassword.AppendChar(c);
        string decryptedPassword = new System.Net.NetworkCredential(string.Empty, securePassword).Password; // this is how to convert it to a string for quick usage to access the protected resource
