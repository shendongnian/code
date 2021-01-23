    static int GetByteArrayHashCode(byte[] array)
    {
        unchecked
        {
            int hash = 17;
    
            // Cycle through each element in the array.
            foreach (byte in array)
            {
                // Update the hash.
                hash = hash * 23 + byte.GetHashCode();            
            }
        }
    }
