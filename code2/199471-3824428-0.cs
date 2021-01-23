    static class MachineKey
    {
        const byte[] ENTROPY = null;
        const string KEY_PATH = @"HKEY_LOCAL_MACHINE\SOFTWARE\company-name-goes-here";
        public static Guid Get()
        {
            try
            {
                string base64 = Microsoft.Win32.Registry.GetValue(KEY_PATH, "HostId", null) as string;
                if (base64 == null) 
                    return Create();
                byte[] cypher = System.Convert.FromBase64String(base64);
                byte[] bytes = System.Security.Cryptography.ProtectedData.Unprotect(cypher, ENTROPY, 
                    System.Security.Cryptography.DataProtectionScope.LocalMachine);
                
                if (bytes.Length != 20 || bytes[0] != 'H' || bytes[1] != 'o' || bytes[2] != 's' || bytes[3] != 't')
                    return Create();
                byte[] guid = new byte[16];
                Array.Copy(bytes, 4, guid, 0, 16);
                return new Guid(guid);
            }
            catch
            {
                return Create();
            }
        }
        static Guid Create()
        {
            byte[] prefix = new byte[] { (byte)'H', (byte)'o', (byte)'s', (byte)'t' };
            Guid id = Guid.NewGuid();
            byte[] store = new byte[20];
            Array.Copy(prefix, store, 4);
            Array.Copy(id.ToByteArray(), 0, store, 4, 16);
            store = System.Security.Cryptography.ProtectedData.Protect(store, ENTROPY,
                System.Security.Cryptography.DataProtectionScope.LocalMachine);
            Microsoft.Win32.Registry.SetValue(KEY_PATH, "HostId", System.Convert.ToBase64String(store));
            return id;
        }
    }
