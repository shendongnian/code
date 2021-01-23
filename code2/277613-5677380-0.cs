    public static unsafe string Copy(string str)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str");
        }
        int length = str.Length;
        string str2 = FastAllocateString(length);
        fixed (char* chRef = &str2.m_firstChar)
        {
            fixed (char* chRef2 = &str.m_firstChar)
            {
                wstrcpyPtrAligned(chRef, chRef2, length);
            }
        }
        return str2;
    }
