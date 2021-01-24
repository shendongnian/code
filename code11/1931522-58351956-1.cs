    [Serializable]
    public class User
    {
        public string Name;
        public string PasswordHash;
        public Roles Role;
    
    
        public User(string name, string password, Roles role)
        {
            Name = name;
    
            // Never store a naked Password!
            // Rather store the hash and everytime you want to check the password
            // compare the hashes!
            PasswordHash = GetHash(password);
    
            // As said actually you should also not store this as a simple modifiable value
            // Since it almost has the same security impact as a password!
            Role = role;
        }
    
        private static string GetHash(string password)
        {
            var unhashedBytes = Encoding.Unicode.GetBytes(password);
    
            var sha256 = new SHA256Managed();
            var hashedBytes = sha256.ComputeHash(unhashedBytes);
    
            return Convert.ToBase64String(hashedBytes);
        }
    
        public bool CheckPassword(string attemptedPassword, string hash)
        {
            var base64AttemptedHash = GetHash(attemptedPassword);
    
            return base64AttemptedHash.Equals(PasswordHash);
        }
    }
    
