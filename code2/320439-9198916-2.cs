    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    public class FollowingTail : IDisposable
    {
        private readonly Stream _fileStream;
        private readonly Timer _timer;
        public FollowingTail(FileInfo file,
                             Encoding encoding,
                             Action<string> fileChanged)
        {
            _fileStream = new FileStream(file.FullName,
                                         FileMode.Open,
                                         FileAccess.Read,
                                         FileShare.ReadWrite);
            _timer = new Timer(o => CheckForUpdate(encoding, fileChanged),
                               null,
                               0,
                               500);
        }
        private void CheckForUpdate(Encoding encoding,
                                    Action<string> fileChanged)
        {
            // Read the tail of the file off
            var tail = new StringBuilder();
            int read;
            var b = new byte[1024];
            while ((read = _fileStream.Read(b, 0, b.Length)) > 0)
            {
                tail.Append(encoding.GetString(b, 0, read));
            }
            // If we have anything notify the fileChanged callback
            // If we do not, make sure we are at the end
            if (tail.Length > 0)
            {
                fileChanged(tail.ToString());
            }
            else
            {
                _fileStream.Seek(0, SeekOrigin.End);
            }
        }
        // Not the best implementation if IDisposable but you get the idea
        // See http://msdn.microsoft.com/en-us/library/ms244737(v=vs.80).aspx
        // for how to do it properly
        public void Dispose()
        {
            _timer.Dispose();
            _fileStream.Dispose();
        }
    }
