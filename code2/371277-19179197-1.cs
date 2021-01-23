        /// <summary>
        /// Derives password bytes
        /// </summary>
        /// <param name="Password">password</param>
        /// <returns>derived bytes</returns>
        private Rfc2898DeriveBytes DerivePass(string Password)
        {
            byte[] hash = CalcHash(Password);
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(Password, hash, _KEY_ITER);
            return pdb;
        }
        /// <summary>
        /// calculates the hash of the given string
        /// </summary>
        /// <param name="buffer">string to hash</param>
        /// <returns>hash value (byte array)</returns>
        private byte[] CalcHash(string buffer)
        {
            RIPEMD160 hasher = RIPEMD160.Create();
            byte[] data = Encoding.UTF8.GetBytes(buffer);
            return hasher.ComputeHash(data);
        }
