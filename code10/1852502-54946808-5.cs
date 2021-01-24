    class TheMoc : IRandomNumberGenerator
    {
        public void NextBytes(byte[] bytes)
        {
            bytes = new byte[] {0x4d, 0x65, 0x64, 0x76};
        }
    }
