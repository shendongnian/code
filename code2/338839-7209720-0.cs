    public IList<int> FindIntInBytes(byte[] bytes, int target)
    {
        IList<int> found = new List<int>();
        unsafe
        {
            fixed (byte* pBytes = bytes)
            {
                byte* pCurrent = pBytes;
                for (int i = 0; i <= bytes.Length - 4; i++, pCurrent++)
                {
                    if (target == *(int*)pCurrent)
                    {
                        found.Add(i);
                    }
                }
            }
        }
        return found;
    }
