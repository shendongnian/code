    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class IMemoryStream : MemoryStream, IStream {
      public IMemoryStream() : base() { }
      public IMemoryStream(byte[] data) : base(data) { }
      #region IStream Members
      public void Clone(out IStream ppstm) { ppstm = null; }
      public void Commit(int grfCommitFlags) { }
      public void CopyTo(
         IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten) { }
      public void LockRegion(long libOffset, long cb, int dwLockType) { }
      public void Read(byte[] pv, int cb, IntPtr pcbRead)
      {
         long bytes_read = base.Read(pv, 0, cb);
         if (pcbRead != IntPtr.Zero) 
            Marshal.WriteInt64(pcbRead, bytes_read);
      }
      public void Revert() { }
      public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
      {
         long pos = base.Seek(dlibMove, (SeekOrigin)dwOrigin);
         if (plibNewPosition != IntPtr.Zero)
            Marshal.WriteInt64(plibNewPosition, pos);
      }
      public void SetSize(long libNewSize) { }
      public void Stat(
         out System.Runtime.InteropServices.ComTypes.STATSTG pstatstg, 
         int grfStatFlag)
      {
         pstatstg = new System.Runtime.InteropServices.ComTypes.STATSTG();
         pstatstg.cbSize = base.Length;
      }
      public void UnlockRegion(long libOffset, long cb, int dwLockType) { }
      public void Write(byte[] pv, int cb, IntPtr pcbWritten)
      {
         base.Write(pv, 0, cb);
         if (pcbWritten != IntPtr.Zero) 
            Marshal.WriteInt64(pcbWritten, (long)cb);
      }
      #endregion
    }
