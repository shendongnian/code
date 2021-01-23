    /// <summary>
    /// This class is a very fast and threadsafe FIFO buffer
    /// </summary>
    public class FastFifo
    {
        private List<Byte> mi_FifoData = new List<Byte>();
        /// <summary>
        /// Get the count of bytes in the Fifo buffer
        /// </summary>
        public int Count
        {
            get 
            { 
                lock (mi_FifoData)
                {
                    return mi_FifoData.Count; 
                }
            }
        }
        /// <summary>
        /// Clears the Fifo buffer
        /// </summary>
        public void Clear()
        {
            lock (mi_FifoData)
            {
                mi_FifoData.Clear();
            }
        }
        /// <summary>
        /// Append data to the end of the fifo
        /// </summary>
        public void Push(Byte[] u8_Data)
        {
            lock (mi_FifoData)
            {
                // Internally the .NET framework uses Array.Copy() which is extremely fast
                mi_FifoData.AddRange(u8_Data);
            }
        }
        /// <summary>
        /// Get data from the beginning of the fifo.
        /// returns null if s32_Count bytes are not yet available.
        /// </summary>
        public Byte[] Pop(int s32_Count)
        {
            lock (mi_FifoData)
            {
                if (mi_FifoData.Count < s32_Count)
                    return null;
                // Internally the .NET framework uses Array.Copy() which is extremely fast
                Byte[] u8_PopData = new Byte[s32_Count];
                mi_FifoData.CopyTo(0, u8_PopData, 0, s32_Count);
                mi_FifoData.RemoveRange(0, s32_Count);
                return u8_PopData;
            }
        }
        /// <summary>
        /// Gets a byte without removing it from the Fifo buffer
        /// returns -1 if the index is invalid
        /// </summary>
        public int PeekAt(int s32_Index)
        {
            lock (mi_FifoData)
            {
                if (s32_Index < 0 || s32_Index >= mi_FifoData.Count)
                    return -1;
                return mi_FifoData[s32_Index];
            }
        }
    }
