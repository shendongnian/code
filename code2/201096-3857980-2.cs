    class SwappablePair
    {
        long m_pair;
        
        public SwappablePair(int x, int y)
        {
            m_pair = ((long)x << 32) | (uint)y;
        }
        /// <summary>
        /// Reads the values of X and Y atomically.
        /// </summary>
        public void GetValues(out int x, out int y)
        {
            long current = Interlocked.Read(ref m_pair);
            
            x = (int)(current >> 32);
            y = (int)(current & 0xffffffff);
        }
        /// <summary>
        /// Sets the values of X and Y atomically.
        /// </summary>
        public void SetValues(int x, int y)
        {
            // If you wanted, you could also take the return value here
            // and set two out int parameters to indicate what the previous
            // values were.
            Interlocked.Exchange(ref m_pair, ((long)x << 32) | (uint)y);
        }
    }
