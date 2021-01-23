    System.Guid g
    g.ToByteArray();
    int[] m_byteOrder = new int[16] // 16 Bytes = 128 Bit 
        {10, 11, 12, 13, 14, 15, 8, 9, 6, 7, 4, 5, 0, 1, 2, 3};
    public int Compare(Guid x, Guid y)
    {
        byte byte1, byte2;
        //Swap to the correct order to be compared
        for (int i = 0; i < NUM_BYTES_IN_GUID; i++)
        {
            byte1 = x.ToByteArray()[m_byteOrder[i]];
            byte2 = y.ToByteArray()[m_byteOrder[i]];
            if (byte1 != byte2)
                return (byte1 < byte2) ? (int)EComparison.LT : (int)EComparison.GT;
        } // Next i 
        return (int)EComparison.EQ;
    }
