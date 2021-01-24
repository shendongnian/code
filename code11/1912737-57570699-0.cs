        public byte Compute(IEnumerable<byte> buffer)
        {
            unchecked
            {
                byte lrc = 0;
                foreach (byte cell in buffer)
                {
                    this.ComputeCore(ref lrc, cell);
                }
                return lrc;
            }
        }
        public byte Compute(ReadOnlySpan<byte> span)
        {
            unchecked
            {
                byte lrc = 0;
                foreach (byte cell in span)
                {
                    this.ComputeCore(ref lrc, cell);
                }
                return lrc;
            }
        }
        private void ComputeCore(ref byte acc, byte cell)
        {
            acc ^= cell;
        }
