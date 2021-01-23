    string password = GetPasswordFromUserInputOrWherever();
    using (var deriveBytes = new Rfc2898DeriveBytes(password, 16))  // 16 byte salt
    {
        byte[] salt = deriveBytes.Salt;
        // now save the salt somewhere safe
        // you'll need it to generate the same byte sequence when decrypting
        using (var rijndael = new RijndaelManaged())
        {
            rijndael.Key = deriveBytes.GetBytes(rijndael.KeySize / 8);
            rijndael.IV = deriveBytes.GetBytes(rijndael.BlockSize / 8);
            // encrypt...
        }
    }
