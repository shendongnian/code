    public class ChecksumTruncate12Bit : IChecksum<int> 
    {
        public int Checksum(byte[] buffer, int size)
        {
            int rv = 0; 
    
            for (int i = 0; i < size; ++i)
            {
                rv += (int)(buffer[i]); 
                rv &= (int)(0x0FFF); 
            }
    
            return rv;
        }
    }
