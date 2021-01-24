    public class Subject {
        public byte[] ZipData(string data) {
            //LoadDictionaries();
            //CallerName = _messageService.GetCallerName();
            var bytes = Encoding.UTF8.GetBytes(data);
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream()) {
                try {
                    using (var gs = new GZipStream(mso, CompressionMode.Compress)) {
                        msi.CopyTo(gs);
                    }
                    byte[] toReturn = mso.ToArray();
                    return toReturn;
                } catch (Exception e) {
                    // _logger.Error(e, MessagesError[CallerName]);
                    return Array.Empty<byte>();
                }
            }
        }
        public string UnzipData(byte[] bytes) {
            //LoadDictionaries();
            //CallerName = _messageService.GetCallerName();
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream()) {
                try {
                    using (var gs = new GZipStream(msi, CompressionMode.Decompress)) {
                        gs.CopyTo(mso);
                    }
                    return Encoding.UTF8.GetString(mso.ToArray());
                } catch (Exception e) {
                    //_logger.Error(e, MessagesError[CallerName]);
                    return string.Empty;
                }
            }
        }
    }
