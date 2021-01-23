    public byte[] ToByteArray()
    {
      byte[] bytes = new byte[Marshal.SizeOf(typeof(TcpKeepAliveConfiguration))];
      unsafe
      {
        fixed (TcpKeepAliveConfiguration* ptr = &this)
        {
          // now you have pinned "this" and obtained a pointer to it in one step
        }
      }
    }
