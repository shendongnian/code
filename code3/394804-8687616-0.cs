    public int Read(byte[] buffer, int index, int length)
    {
        unsafe
        {
            fixed(byte *ptr = buffer)
            {
                byte *ptr = ptr + index;
            }
        }
    }
