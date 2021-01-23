    unsafe static ulong Fetch64(byte[] p, int ofs = 0)
    {
      fixed (byte* bp = p)
      {
        return *((ulong*)(bp + ofs));
      }
    }
