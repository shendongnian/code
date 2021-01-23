        private void ResumeCopy(FileStream source, FileStream dest)
        {
            byte[] buffer = new byte[0x10000]; //use 64kB buffer
            int read;
            source.Seek(dest.Length, SeekOrigin.Begin);
            while ((read = source.Read(buffer, 0, buffer.Length)) > 0)
            {
                dest.Write(buffer, 0, read);
                dest.Flush();
            }
        }
