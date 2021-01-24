    string testDateString = "2015-07-08T11:31:53+01:00";
    string testNonce = "186269";
    string testSecret = "Ok4IWYLBHbKn8juM1gFPvQxadieZmS2";
    SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
    byte[] hashedDataBytes = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(testNonce + testDateString + testSecret));
    var hexString = BitConverter.ToString(hashedDataBytes).Replace("-", string.Empty).ToLower();
    string Sha1Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(hexString));
