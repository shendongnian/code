    private bool CheckPassword(string salt, string password) {
      var hash = Encoding.ASCII.GetBytes(salt + password);
      var sha1 = new SHA1CryptoServiceProvider();
      var sha1hash = sha1.ComputeHash(hash);
      var hashedPassword = ASCIIEncoding.GetString(sha1hash);
    
      return (Properties.Settings.Default.adminPass == hashedPassword );           
}
