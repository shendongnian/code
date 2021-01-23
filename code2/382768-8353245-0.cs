    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    namespace StreamTest
    {
        public class EnumeratorStream : Stream
        {
            private readonly IEnumerator<string> source;
            private readonly Encoding encoding;
            public Encoding Encoding { get { return encoding; } }
            private byte[] current = new byte[0];
            private int currentPos = 0;
            public EnumeratorStream(IEnumerable<string> source, Encoding encoding)
            {
                if (source == null) throw new ArgumentNullException("source");
                if (encoding == null) encoding = Encoding.Default;
                this.source = source.GetEnumerator();
                this.encoding = encoding;
            }
            private bool MoveNext()
            {
                while (source.MoveNext())
                {
                    if (source.Current.Length > 0)
                    {
                        current = encoding.GetBytes(source.Current);
                        currentPos = 0;
                        return true;
                    }
                }
                current = new byte[0];
                currentPos = 0;
                return false;
            }
            #region Overrides of Stream
            public override bool CanRead { get { return true; } }
            public override bool CanSeek { get { return false; } }
            public override bool CanWrite { get { return false; } }
            public override int Read(byte[] buffer, int offset, int count)
            {
                if (buffer == null) throw new ArgumentNullException("buffer");
                if (offset < 0) throw new ArgumentOutOfRangeException("offset");
                if (offset + count > buffer.Length) throw new ArgumentException("Not enough buffer space");
                int totalWritten = 0;
                while (count > 0)
                {
                    int remaining = current.Length - currentPos;
                    if (remaining == 0 && !MoveNext()) break;
                    remaining = current.Length - currentPos;
                    if (remaining <= 0) break;
                    if (remaining > count)
                    {
                        remaining = count;
                    }
                    Array.Copy(current, currentPos, buffer, offset, remaining);
                    offset += remaining;
                    count -= remaining;
                    totalWritten += remaining;
                    currentPos += remaining;
                }
                return totalWritten;
            }
            public override void Flush() { }
            public override long Seek(long offset, SeekOrigin origin) { throw new NotSupportedException(); }
            public override void SetLength(long value) { throw new NotSupportedException(); }
            public override void Write(byte[] buffer, int offset, int count) { throw new NotSupportedException(); }
            public override long Length { get { throw new NotSupportedException(); } }
            public override long Position
            {
                get { throw new NotSupportedException(); }
                set { throw new NotSupportedException(); }
            }
            #endregion
        }
    }
