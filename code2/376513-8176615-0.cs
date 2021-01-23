    public static unsafe void SetLength(string s, int length)
    {
        fixed(char *p = s)
        {
            int *pi = (int *)p;
            if (length<0 || length > pi[-2])
                throw( new ArgumentOutOfRangeException("length") );
            pi[-1] = length;
            p[length] = '\0';
        }
    }
