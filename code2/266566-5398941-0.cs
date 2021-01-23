    class ArrivedDetails
    {
    ///...
    
        public static ArrivedDetails CreateFromEncryptedKey(string encrypted)
        {
            return DataProtect.deserializeXML(DataProtect.DecryptData(encrypted));
        }
    ///...
