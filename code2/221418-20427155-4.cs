        public class SecuredPassword
        {
            private const int saltSize = 256;
            private readonly byte[] hash;
            private readonly byte[] salt;
    
            public byte[] Hash
            {
            get { return hash; }
        }
        public byte[] Salt
        {
            get { return salt; }
        }
        public SecuredPassword(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return; 
            using (var deriveBytes = new Rfc2898DeriveBytes(plainPassword, saltSize))
            {
                salt = deriveBytes.Salt;
                hash = deriveBytes.GetBytes(saltSize);
            }
        }
        public SecuredPassword(byte[] hash, byte[] salt)
        {
            this.hash = hash;
            this.salt = salt;
        }
        public bool Verify(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false; 
            using (var deriveBytes = new Rfc2898DeriveBytes(password, salt))
            {
                byte[] newKey = deriveBytes.GetBytes(saltSize);
                return newKey.SequenceEqual(hash);
            }
        }
    }
