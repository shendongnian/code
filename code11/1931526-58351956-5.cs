    [Serializable]
    public class User
    {
        private const SECRET_SALT = "1234My_Example";
        public string Name;
        // Never store a naked Password!
        // Rather store the hash and everytime you want to check the password
        // compare the hashes!
        public string PasswordHash;
        // As said actually you should also not store this as a simple modifiable value
        // Since it almost has the same security impact as a password!
        public Roles Role;
    
        public User(string name, string password, Roles role)
        {
            Name = name;
            // Instead of the raw password store a hash
            PasswordHash = GetHash(password);
            Role = role;
        }
    
        // Compare the hash of the given password attempt to the stored one
        public bool CheckPassword(string attemptedPassword, string hash)
        {
            var base64AttemptedHash = GetHash(attemptedPassword);
    
            return base64AttemptedHash.Equals(PasswordHash);
        }
        private static string GetHash(string password)
        {
            // Use the secret salt so users can not simply edit the stored file
            // and add a users password brute-forcing the known blank hashing methods
            var unhashedBytes = Encoding.Unicode.GetBytes(SECRET_SALT + password);
    
            var sha256 = new SHA256Managed();
            var hashedBytes = sha256.ComputeHash(unhashedBytes);
    
            return Convert.ToBase64String(hashedBytes);
        }
    }
    
