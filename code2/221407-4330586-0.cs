    string password = GetPasswordFromUserInput();
    // specify that we want to randomly generate a 20-byte salt
    using (var deriveBytes = new Rfc2898DeriveBytes(password, 20))
    {
        byte[] salt = deriveBytes.Salt;
        byte[] key = deriveBytes.GetBytes(20);  // derive a 20-byte key
        // save salt and key to database
    }
