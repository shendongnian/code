    public static byte ComputeAdditionChecksum(byte[] data)
    {
        byte sum = 0;
        unchecked // Let overflow occur without exceptions
        {
            foreach (byte b in data)
            {
                sum += b;
            }
        }
        return sum;
    }
