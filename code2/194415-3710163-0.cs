    public class Cryptographer
    {
        private byte[] Keys { get; set; }
    
        public Cryptographer(string password)
        {
            Keys = Encoding.ASCII.GetBytes(password);
        }
    
        public void Encrypt(byte[] data)
        {
            for(int i = 0; i < data.Length; i++)
            {
                data[i] = (byte) (data[i] ^ Keys[i % Keys.Length]);
            }
        }
    
        public void Decrypt(byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(Keys[i % Keys.Length] ^ data[i]);
            }
        }
    }
