    public class ChecksumTruncate12BitUint : IChecksum<uint> 
    {
        public uint Checksum(byte[] buffer, int size)
        {
            uint rv = 0; 
    
            for (int i = 0; i < size; ++i)
            {
                rv += (uint)(buffer[i]); 
                rv &= (uint)(0x0FFF); 
            }
    
            return rv;
        }
    }
