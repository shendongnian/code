    string result = string.Empty;
    long ticks = DateTime.Now.Ticks;
    while (ticks>0)
    {
       int n = ticks % 36;
       ticks /= 36;
       char c = n<26 ? ('A'+n) : ('0'+n-26);
       result = c + result;
    }
