    public class SeekableAesStream: Stream
    {
        private Stream baseStream;
        private AesManaged aesAlg;
        private ICryptoTransform encryptor;
        public bool autoDisposeBaseStream { get; set; } = true;
        /// <param name="iv">//** WARNING **: MUST be unique for each stream otherwise there is NO security</param>
        public SeekableAesStream(Stream baseStream, string password, byte[] iv)
        {
            this.baseStream = baseStream;
            using (var key = new PasswordDeriveBytes(password, iv))
            {
                aesAlg = new AesManaged();
                aesAlg.KeySize = 128;
                aesAlg.Mode = CipherMode.ECB;
                aesAlg.Padding = PaddingMode.None;
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            }
        }
        private void cipher(byte[] buffer, int offset, int count, long streamPos)
        {
            //find block number
            var blockSizeInByte = aes.BlockSize / 8;
            var blockNumber = (streamPos / blockSizeInByte) + 1;
            var keyPos = streamPos % blockSizeInByte;
            //buffer
            var outBuffer = new byte[blockSizeInByte];
            var nonce = new byte[blockSizeInByte];
            var init = false;
            for (int i = offset; i < count; i++)
            {
                //encrypt the nonce to form next xor buffer (unique key)
                if (!init || (keyPos % blockSizeInByte) == 0)
                {
                    BitConverter.GetBytes(blockNumber).CopyTo(nonce, 0);
                    encryptor.TransformBlock(nonce, 0, nonce.Length, outBuffer, 0);
                    if (init) keyPos = 0;
                    init = true;
                    blockNumber++;
                }
                buffer[i] ^= outBuffer[keyPos]; //simple XOR with generated unique key
                keyPos++;
            }
        }
        public override bool CanRead { get { return baseStream.CanRead; } }
        public override bool CanSeek { get { return baseStream.CanSeek; } }
        public override bool CanWrite { get { return baseStream.CanWrite; } }
        public override long Length { get { return baseStream.Length; } }
        public override long Position { get { return baseStream.Position; } set { baseStream.Position = value; } }
        public override void Flush() { baseStream.Flush(); }
        public override void SetLength(long value) { baseStream.SetLength(value); }
        public override long Seek(long offset, SeekOrigin origin) { return baseStream.Seek(offset, origin); }
        public override int Read(byte[] buffer, int offset, int count)
        {
            var streamPos = Position;
            var ret = baseStream.Read(buffer, offset, count);
            cipher(buffer, offset, count, streamPos);
            return ret;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            cipher(buffer, offset, count, Position);
            baseStream.Write(buffer, offset, count);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                encryptor?.Dispose();
                aesAlg?.Dispose();
                if (autoDisposeBaseStream)
                    baseStream?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
