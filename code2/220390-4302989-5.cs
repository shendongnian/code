    string password = GetPasswordFromUserInputOrWherever();
    byte[] salt = GetSaltFromWhereverYouPreviouslySavedIt();
    using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
    using (var rijndael = new RijndaelManaged())
    {
        rijndael.Key = deriveBytes.GetBytes(rijndael.KeySize / 8);
        rijndael.IV = deriveBytes.GetBytes(rijndael.BlockSize / 8);
        // decrypt...
    }
