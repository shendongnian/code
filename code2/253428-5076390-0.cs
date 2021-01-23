    struct LoginPacket
    {
        public int unk1;
        public string username;
        public string password;
        public void Parse(byte[] b)
        {
            unk1 = BitConverter.ToInt32(b, 0);
            username = Encoding.UTF8.GetString(b, 4, 17);
            password = Encoding.UTF8.GetString(b, 4 + 17, 17);
        }
    }
