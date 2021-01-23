    public class FollowingTail
    {
        private long _position;
        private readonly Action<string> _fileChanged;
        private readonly Encoding _encoding;
        public FollowingTail(FileInfo file,
                             Encoding encoding,
                             Action<string> fileChanged)
        {
            _position = 0;
            _fileChanged = fileChanged;
            _encoding = encoding;
            var fsw = new FileSystemWatcher(file.DirectoryName,
                                            file.Name)
                            {
                                EnableRaisingEvents = true,
                                IncludeSubdirectories = false
                            };
            fsw.Changed += FileChanged;
        }
        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                var tail = new StringBuilder();
                using (var s = new FileStream(e.FullPath, 
                                              FileMode.Open,
                                              FileAccess.Read, 
                                              FileShare.Read))
                {
                    // Move to the right position in the stream to get new stuff
                    long length = s.Length;
                    long start = length - _position;
                    if (start > 0)
                    {
                        s.Seek(-start, SeekOrigin.End);
                        // Read the contents of the file and append them into a
                        // string to send later
                        var buffer = new byte[1024];
                        int read;
                        while ((read = s.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            tail.Append(_encoding.GetString(buffer, 0, read));
                        }
                    }
                    // Make sure we move the position to the end now we are done
                    _position = length;
                }
                // Make sure that we actually have something new to report and
                // then call the file changed action
                var extra = tail.ToString();
                if (!string.IsNullOrEmpty(extra))
                {
                    _fileChanged(extra);
                }
            }
            catch (IOException)
            {
                // This is thrown if the file is locked
                // and we cannot read it at all sadly :-(
                // Maybe one of the clever people on SO know
                // a better way to open the file??
            }
        }
    }
