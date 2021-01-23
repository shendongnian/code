        public static class StreamExtensions
        {
            public static void CopyTo(this Stream source, Stream destination)
            {
                if (source == null)
                {
                    throw new ArgumentNullException("source");
                }
                if (destination == null)
                {
                    throw new ArgumentNullException("destination");
                }
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = source.Read(buffer, 0, buffer.Length)) > 0)
                {
                    destination.Write(buffer, 0, bytesRead);
                }
            }
        }
